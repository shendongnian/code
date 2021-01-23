    struct Students
    {
       public string name;
       public string family;
       public int ID;
       public string Major;
       public int studentCode;
    } 
    
    class Student
    {
        public static void ShowStudent() 
        {
            Console.Clear();
            Console.WriteLine("This is Student's Section:\n");
            Console.WriteLine("====================================");
            Console.WriteLine("Enter the Number Of the Section you want to Work with:\n");
            Console.WriteLine("1 Submit");
            Console.WriteLine("2 Edit");
            Console.WriteLine("3 Back");
            string choice = Console.ReadLine();
            Students[] students = null;
    
            switch (choice)
            {
                case "1":
                    students = ReciveStudent();
                    break;
                case "2":
                    break;
                case "3":
                    Program.mainShow();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Please Enter INrange Number.\nPress any Key to Continue....");
                    Console.ReadKey();
                    ShowStudent();
                    break;
            }
            // Use variable 'students' here
            // Remember to check for null
        }
    
        public static Students[] ReceiveStudent()
        {
            Console.Clear();
            int n;
    
            Console.WriteLine("How Many Student's you Want to Enter?");
            n = Convert.ToInt32(Console.ReadLine());
            Students[]  st = new Students[n];
    
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Student ID:");
                st[i].ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student CODE:");
                st[i].studentCode = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name:");
                st[i].name = Console.ReadLine();
                Console.WriteLine("Enter Student Family:");
                st[i].family = Console.ReadLine();
                Console.WriteLine("Enter Student Major:");
                st[i].Major = Console.ReadLine();                         
            }
    
            ShowStudent();
            return st;
        }
    }
