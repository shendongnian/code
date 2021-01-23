    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string first ="";
                string last ="";
                string birthday ="";
                GetStudentInfo(ref first, ref last, ref birthday);
                //removed extra brackets
                PrintStudentDetails(ref first, ref last, ref birthday);
                GetTeacherInfo();
                GetCourseInfo();
                GetProgramInfo();
                GetDegreeInfo();
            }
    //student information
            //passed references in to this method
            static void GetStudentInfo(ref string firstName, ref string LastName, ref string birthday)
            {
                Console.WriteLine("Enter the student's first name: ");
                firstName = Console.ReadLine();
                Console.WriteLine("Enter the student's last name: ");
                lastName = Console.ReadLine();
                Console.WriteLine("Enter the student's birthday: ");
                birthday = Console.ReadLine(); 
            }
            static void PrintStudentDetails(ref string first, ref string last, ref string birthday)
            {
                //removed lines that reassigned variables
                Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday);
                Console.ReadLine();
            }
        }
    }
