    class Program
        {
           
            static void Main(string[] args)
            {
    
                
    
                Console.WriteLine("Enter you name:");
                string name = Console.ReadLine();
    
                Console.WriteLine(gradeDetails(name));
    
                Console.ReadLine();
            }
    
            public static string gradeDetails(string name)
            {
                 List<Student> students = new List<Student>()
                    {
                        new Student{ Fname = "Scott",LName ="Dee",Course = "Computing", FinalGrade = "66.66m"},
                        new Student{Fname = "Joe",LName = "Don",Course = "Chemestry", FinalGrade = "80.77m"}
                    };
    
                var student = students.SingleOrDefault(s => s.LName.ToLower() == name.ToLower());
    
                if (student!=null)
                {
                    return student.Fname + "" + student.LName + "" + student.Course + "" + student.FinalGrade;
                }
    
                return string.Empty;
            }
        }
