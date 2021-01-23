    namespace Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                int i = 0;
                foreach (string arg in args)
                {
                    i++;
                    Console.WriteLine("Argument {0}: {1}", i, arg);
                }
                Console.ReadLine();
            }
        
        }
    }
