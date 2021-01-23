    class Program
    {
        public class Student
        {
            public string forename { get; set; }
            public string surname { get; set; }
            public string prog_title { get; set; }
            public string prog_code { get; set; }
            public int id_number { get; set; }
            public float averageGrade { get; set; }
            public Student(string fname, string surname, string prog_title, string prog_code, int id_number)
            {
                forename = fname;
                this.surname = surname;
                this.prog_title = prog_title;
                this.prog_code = prog_code;
                this.id_number = id_number;
                averageGrade = 0.0F;
            }
        }
        public class module_data
        {
            public string module_code { get; set; }
            public string module_title { get; set; }
            public int module_mark { get; set; }
            public module_data(string mcode, string mname, int score)
            {
                module_code = mcode;
                module_title = mname;
                module_mark = score;
            }
        }
        static void Main(string[] args)
        {
            Student[] students = new Student[4]
                {
                    new Student( "Mark", "Anderson", "Comp", "CIS2117", 0),
                     new Student( "Tom", "Jones", "Comp", "CIS2117", 1),
                     new Student ("Tim", "Jones", "Comp", "CIS2117", 2),
                     new Student( "Tim", "Bones", "Comp", "CIS2117", 3)
                };
            module_data[] modules = new module_data[4]
            {
                new module_data( "7", "App Dev", 0),
                new module_data( "7", "App Dev", 1),
                new module_data("7", "App Dev", 2),
                new module_data("7", "App Dev", 3)
            };
            printAllStudent(students);
            Console.ReadKey();
        }
        static void printAllStudent(Student[] students)
        {
            foreach (Student s in students)
            {
                printStudent(s);
            }
        }
        static void printStudent(Student student)
        {
            Console.WriteLine("Name: " + student.forename + " " + student.surname);
            Console.WriteLine("Id: " + student.id_number);
            Console.WriteLine("AV grade: " + student.averageGrade);
            Console.WriteLine("Course Title: " + student.prog_title);
            Console.WriteLine("Course Code: " + student.prog_code);
        }
        static void printModule(module_data m)
        {
            Console.WriteLine("Module Code: " + m.module_code);
            Console.WriteLine("Module Name: " + m.module_title);
            Console.WriteLine("Score: " + m.module_mark);
        }
    }
