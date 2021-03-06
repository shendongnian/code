    class Program
    {
        //Use a class instead of a struct to store your data in most cases... see link
        public class Student
        {
            public string forename { get; set; }
            public string surname { get; set; }
            public string prog_title { get; set; }
            public string prog_code { get; set; }
            public int id_number { get; set; }
            public float averageGrade { get; set; }
            //I ommited the defualt {} constructor so this is your only choice to create a new class
            //you may want to choose to put it back in for more flexibility...see link
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
            //I'm initializing the array using object initialization syntax ... see link
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
        //Because an array implements IEnumerable you should use a foreach loop instead of a for loop
        static void printAllStudent(Student[] students)
        {
            foreach (Student s in students)
            {
                printStudent(s);
            }
        }
        //You could pass a null in here and this would have a run-time error.
        //It would be safer to check if student!=null here first (but I left it for you)
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
