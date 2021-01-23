        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("You have entered {0} command line arguments",args.Length);
            
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("{0}", args[i]);
            }
            Console.ReadLine();
        }
