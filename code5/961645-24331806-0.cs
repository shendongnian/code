    public static void Main()
    {
        int iterations = 50 * 1000 * 1000;
    
        double nan = double.NaN;
        double notNan = 42;
    
        Stopwatch sw = Stopwatch.StartNew();
    
        bool isNan;
        for (int i = 0; i < iterations; i++)
        {
            isNan = IsNaN(nan);     // true
            isNan = IsNaN(notNan);  // false
        }
    
        sw.Stop();
        Console.WriteLine("IsNaN: {0}", sw.ElapsedMilliseconds);
    
        sw = Stopwatch.StartNew();
    
        for (int i = 0; i < iterations; i++)
        {
            isNan = double.IsNaN(nan);     // true
            isNan = double.IsNaN(notNan);  // false
        }
    
        sw.Stop();
        Console.WriteLine("double.IsNaN: {0}", sw.ElapsedMilliseconds);
    
        Console.Read();
    }
