    public  static void EvenNumbers()
        {
            int written = int.Parse(Console.ReadLine());
            int modNumber = written % 2 == 1 ? 0 : 1;
            for (int i = 0; i <= written; i++)
            {
                if (i % 2 == modNumber)
                    continue;
                Console.WriteLine(i);
            }
        }
