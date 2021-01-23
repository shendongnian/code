    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Code { get; set; } // not sure what the J M T K code is
        public string Telephone { get; set; }
        public string Email { get; set; }
        public double Gpa { get; set; }
    }
    private static void Main(string[] args)
    {
    FileStream fStream = new FileStream("Students.txt", FileMode.Open, FileAccess.Read);
    StreamReader inFile = new StreamReader(fStream);
    string inValue;
    string[] values;
    List<Student> students = new List<Student>();
    while (!inFile.EndOfStream)
    {
        inValue = inFile.ReadLine();
        if (inValue.StartsWith("(LIST (LIST "))
        {
            values = inValue.Split(" ".ToCharArray());
            Student student = new Student();
            student.LastName = values[2];
            student.FirstName = values[3];
            student.Code = values[4];
            student.Telephone = values[6];
            student.Email = values[7];
            student.Gpa = Convert.ToDouble(values[8]);
            students.Add(student);
        }
    }
    var noTelephone = students.Count(x => x.Telephone == "'NONE");
    int noEmails = students.Count(x => x.Email == "'NONE");
    Console.WriteLine("The average gpa is..." + students.Average(x => x.Gpa));
    Console.WriteLine("Total last names with Anderson is..." + students.Count(x => x.LastName == "'Anderson"));
    Console.WriteLine("Total number of students is..." + students.Count);
    Console.WriteLine("Total with no emails is..." + noEmails);
    Console.WriteLine("Total with no telephone is..." + noTelephone);
    Console.WriteLine("Total with no telephone or emails are..." + (noEmails + noTelephone));
    Console.ReadKey();
        }
    }
