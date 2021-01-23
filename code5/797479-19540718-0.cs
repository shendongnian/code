        static void Main(string[] args)
        {
            int[] ar = new int[10002];
            int n;
            if (int.TryParse(Console.ReadLine(), out n))
            {
                int nr;
                for (int i = 0; i < n; i++)
                {                
                    if (int.TryParse(Console.ReadLine(), out nr))
                    {
                        ar[i] = nr;
                    }
                }
    
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine(ar[i]);
                }
            }
            Console.ReadKey();
        }
