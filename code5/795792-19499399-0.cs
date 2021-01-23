    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public decimal FinalGrade { get; set; }
        public Student(string firstName,
                       string lastName,
                       string course)
        {
            FirstName = firstName;
            LastName = lastName;
            Course = course;
            FinalGrade = 0;
        }
        
        // This will first call the constructor above and then continue.
        public Student(string firstName,
                       string lastName,
                       string course,
                       decimal finalGrade) : this(firstName, lastName, course)
        {
            FinalGrade = finalGrade;
        }
        // By overriding ToString we can use Console.WriteLine(student) directly.
        public override string ToString()
        {
            return string.Format(@"FirstName: {0}, LastName: {1}, Course: {2}, FinalGrade: {3}",
                                 FirstName,
                                 LastName,
                                 Course,
                                 FinalGrade);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create our students.
            List<Student> students = new List<Student>
                                     {
                                         new Student("John", "Test", "Computing"),
                                         new Student("Tim", "Test", "Computing", 8.25m)
                                     };
            string user = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Please enter the name of the student:");
                user = Console.ReadLine();
                if (user.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;
                // Find the student or return null.
                Student student = students.FirstOrDefault(s => s.FirstName.Equals(user, StringComparison.OrdinalIgnoreCase));
                if (student != null)
                {
                    Console.WriteLine("Student info:");
                    Console.WriteLine(student);
                }
                else
                {
                    Console.WriteLine("Student '" + user + "' not found.");
                }
                Console.WriteLine();
                // Wait until a key is pressed.
                Console.WriteLine("Press a key to continue..");
                Console.ReadKey(true);
            } while (true);
        }
    }
