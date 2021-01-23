    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            public class Student
            {
                public string firstname;
                public string lastname;
                public string address;
                public string country;
                public string state;
                public string tele;
            }
            public class StudentProcessor
            {
                //Student info ..
                public Student GetStudentInfo()
                {
                    Student s = new Student();
                    Console.WriteLine("Enter Student's first name : ");
                    s.firstname = Console.ReadLine();
    
                    Console.WriteLine("Enter Student's last name : ");
                    s.lastname = Console.ReadLine();
    
                    Console.WriteLine("Enter Student's Address : ");
                    s.address = Console.ReadLine();
    
                    Console.WriteLine("Enter Student's country :");
                    s.country = Console.ReadLine();
    
                    Console.WriteLine("Enter Student's state : ");
                    s.state = Console.ReadLine();
    
                    Console.WriteLine("Enter Student's Telephone number :");
                    s.tele = Console.ReadLine();
    
                    return s;
                }
                public void printStudentInfo(Student s)
                {
                    Console.WriteLine("Student name is" + s.firstname + s.lastname);
                    Console.WriteLine("Prof address is " + s.address);
                    Console.WriteLine("Student country/state is" + s.country + s.state);
                    Console.WriteLine("Student telephone is " + s.tele);
    
                }
            }
            static void Main(string[] args)
            {
                StudentProcessor p = new StudentProcessor();
                Student s = p.GetStudentInfo();
                p.printStudentInfo(s);
    
            }
    
        }
    }
