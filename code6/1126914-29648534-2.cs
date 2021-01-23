    float fl = float.NegativeInfinity;
    long cycles = 0;
    while (true)
    {
        double dbl = fl;
        float fl2 = (float)dbl;
        int flToInt1 = new Ieee754.Int32SingleConverter { Single = fl }.Int32;
        int flToInt2 = new Ieee754.Int32SingleConverter { Single = fl2 }.Int32;
        if (flToInt1 != flToInt2)
        {
            Console.WriteLine("\nDifferent: {0} (Int32: {1}, {2})", fl, flToInt1, flToInt2);
        }
        if (fl == 0)
        {
            Console.WriteLine("\n0, Sign: {0}", flToInt1 < 0 ? "-" : "+");
        }
        if (fl == float.PositiveInfinity)
        {
            fl = float.NaN;
        }
        else if (float.IsNaN(fl))
        {
            break;
        }
        else
        {
            fl = Ieee754.NextSingle(fl);
        }
        cycles++;
        if (cycles % 100000000 == 0)
        {
            Console.Write(".");
        }
    }
    Console.WriteLine("\nDone");
    Console.ReadKey();
