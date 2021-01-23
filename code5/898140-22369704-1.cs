    class Program
    {
        static void Main()
        {
            for (int i = 100; i >= 1; i--)
            {
                if ((i % 10) == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(i.ToString() + " ");   
            }
        }
    }
