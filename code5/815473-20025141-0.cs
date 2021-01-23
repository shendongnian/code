    private static void Main(string[] args)
    {
        //Console.WriteLine("Checking {0}", i);
        int loops = 10;
        long averageModulo = 0;
        long averageCeiling = 0;
        for (int l = 0; l < loops; l++)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 10000000; i++)
            {
                int modulus = i % 10;
                int distanceFromTen = modulus == 0 ? 0 : 10 - modulus;
            }
            sw.Stop();
            Stopwatch swTwo = new Stopwatch();
            swTwo.Start();
            for (int i = 0; i < 10000000; i++)
            {
                int distanceFromTenTwo = (int)(Math.Ceiling(i / 10d) * 10 - i);
            }
            swTwo.Stop();
            Console.WriteLine("Modulo:       {0} ({1}ms)", sw.ElapsedTicks, sw.ElapsedMilliseconds);
            averageModulo += sw.ElapsedTicks;
            Console.WriteLine("Math.Ceiling: {0} ({1}ms)", swTwo.ElapsedTicks, swTwo.ElapsedMilliseconds);
            averageCeiling += swTwo.ElapsedTicks;
            Console.WriteLine("");
        }
        Console.WriteLine("Average modulo:  {0}", averageModulo / loops);
        Console.WriteLine("Average ceiling: {0}", averageCeiling / loops);
        Console.ReadLine();
    }
