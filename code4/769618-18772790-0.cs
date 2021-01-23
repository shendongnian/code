    struct student
    {
        public int s_id;
        public String s_name, c_name, dob;
    }
    class Program
    {
        static void Main(string[] args)
        {
            student[] arr = new student[4];
            
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please enter StudentId, StudentName, CourseName, Date-Of-Birth");
                arr[i].s_id = Int32.Parse(Console.ReadLine());
                arr[i].s_name = Console.ReadLine();
                arr[i].c_name = Console.ReadLine();
                arr[i].s_dob = Console.ReadLine();
           }
        }
    }
