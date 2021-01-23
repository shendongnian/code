      using System;
      using System.Collections.Generic;
      using System.Text;
      using System.Threading.Tasks;
      namespace ConsoleApplication1
      {
      class Program
       {
        public class student_data
        {
            public string forename;
            public string surname;
            public int id_number;
            public float averageGrade;
            public string ptitle;
            public string pcode;
        }
        public class module_data
        {
            public string mcode;
            public string mtitle;
            public int mark;
        }
       
        static void printStudent(student_data student)
        {
            Console.WriteLine("Name: " + student.forename + " " + student.surname);
            Console.WriteLine("Id: " + student.id_number);
            Console.WriteLine("Av grade: " + student.averageGrade);
            Console.WriteLine("Programme Title: " + student.ptitle);
            Console.WriteLine("Programme Code: " + student.pcode);
            Console.WriteLine(" ");
        }
        static void printModule(module_data module)
        {
            Console.WriteLine("Module Code: " + module.mcode);
            Console.WriteLine("Module Title: " + module.mtitle);
            Console.WriteLine("Module Mark: " + module.mark);
            Console.WriteLine(" ");
        }
        static void Main(string[] args)
        {
            List<student_data> students = new List<student_data>();
            student_data student = new student_data();
            student.forename = "Mark";
            student.surname = "Anderson";
            student.id_number = 1;
            student.ptitle = "Title1";
            student.pcode = "Code1";
            students.Add(student);
            List<module_data> modules = new List<module_data>();
            module_data module = new module_data();
            module.mcode = "MCode1";
            module.mtitle = "MTitle1";
            module.mark = 10;
            modules.Add(module);
            foreach (student_data value in students)
            {
                printStudent(value);
            }
            foreach (module_data value in modules)
            {
                printModule(value);
            }
            Console.ReadLine();
        }
      }
    }
