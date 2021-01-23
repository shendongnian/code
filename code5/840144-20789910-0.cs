    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Console.WriteLine("Start Here... Press any key");
            var key = Console.ReadKey(true);
    
            switch (key.Key)
            {
                case ConsoleKey.A:
                    goto MyLabel;
                    
                case ConsoleKey.B:
                    goto MyLabel2;
                    
                case ConsoleKey.C:
                    goto MyLabel3;
                    
                default:
                    Console.WriteLine("Bad Choice");
                    goto Start;
                    
            }
    
        MyLabel:
            Console.WriteLine("MyLabel: A");
            goto Start;
    
        MyLabel2:
            Console.WriteLine("MyLabel: B");
            goto Start;
    
    
        MyLabel3:
            Console.WriteLine("MyLabel: C");
            goto Start;
        }
    }
