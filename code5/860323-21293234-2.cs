        public static void Main(string[] args)
        {
            for (;;)
            {
                var val = int.Parse(Console.ReadLine());
                for (int i = 1; i <= val; i++)
                {
                    if (i % 10 == 0)
                    {
                        Console.WriteLine("{0} {0}", i);
                    }
                    else
                    {
                        Console.Write("{0} ", i);
                    }
                }
                Console.WriteLine();
            }
        }
