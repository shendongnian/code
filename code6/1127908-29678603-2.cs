    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                //variables before the method that needs them, not after
                string first ="";
                string last ="";
                string birthday ="";
                GetStudentInfo(ref first, ref last, ref birthday);
                //removed extra brackets
                PrintStudentDetails(first, last, birthday);
                GetTeacherInfo();
                GetCourseInfo();
                GetProgramInfo();
                GetDegreeInfo();
            }
    //student information
            //passed references in to this method
            static void GetStudentInfo(ref string firstName, ref string lastName, ref string birthday)
            {
                Console.WriteLine("Enter the student's first name: ");
                firstName = Console.ReadLine();
                Console.WriteLine("Enter the student's last name: ");
                lastName = Console.ReadLine();
                Console.WriteLine("Enter the student's birthday: ");
                birthday = Console.ReadLine(); 
            }
            static void PrintStudentDetails(string first, string last, string birthday)
            {
                //removed lines that reassigned variables
                Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday);
                Console.ReadLine();
            }
        }
    }
