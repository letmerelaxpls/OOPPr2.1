using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }

    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }
}


class Program
{
    static void Main(string[] args)
    {

        string fileName = "students.txt";


        List<Student> students = new List<Student>();
        using (StreamReader sr = new StreamReader(fileName))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                string name = parts[0].Trim();
                int grade = int.Parse(parts[1].Trim());
                students.Add(new Student(name, grade));
            }
        }


        var filteredStudents = students.Where(s => s.Grade >= 4);
        Console.WriteLine("Result of filtration by grades: ");

        foreach (var student in filteredStudents)
        {
            Console.WriteLine("{0}: {1}", student.Name, student.Grade);
        }
    }
}


