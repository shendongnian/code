    class Test
    {
        static void PrintName()
        {
            Console.Out.Write("Enter your name: ");
            string name = Console.In.ReadLine();
            Console.WriteLine(name);
    
            Console.Out.Write("\nEnter R to restart: ");
            char r = Convert.ToChar(Console.In.Read());
    
            if (r.ToString().Equals("r", StringComparison.OrdinalIgnoreCase))
            {
                Console.In.ReadLine();
                PrintName();
            }
            else
                Environment.Exit(0);
    
        }
    
        static void Main(string[] args)
        {
            PrintName();
        }
    }
