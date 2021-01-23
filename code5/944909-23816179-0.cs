    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Multiplication Tables");
    
            for (int i = 2; i <= 12; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine("{0}*{1}={2}", i, j, i*j);
                }
            }
    
            Console.ReadLine(); // <-- Both loops now complete
        }
    }
