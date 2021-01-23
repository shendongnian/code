    static void Main(string[] args)
        {
            Console.WriteLine("****Phone Dialing Program****\n");
            char first = GetInput("first");
            char second = GetInput("second");
            char third = GetInput("third");
            char fourth = GetInput("fourth");
            char fifth = GetInput("fifth");
            char sixth = GetInput("sixth");
            char seventh = GetInput("seventh");
            char eighth = GetInput("eigth");
            Console.Write(new string(new []{first,second,third,fourth,fifth,sixth,seventh,eighth}));
            Console.Read();
        }
        static char GetInput(string count)
        {
            Console.WriteLine("Enter your " + count + " character:");
            return Console.ReadLine()[0];
        }    
