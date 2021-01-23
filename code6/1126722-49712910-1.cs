    public static void Main(string[] args)
    {  
         CyclesPerSecond = GetCyclesPerSeond();
         for (var i = 0; i < 3; i++)
             Console.WriteLine($"CyclesPerSecond: {GetCyclesPerSeond(),5:0} ");
         for (var i = 0; i < 10; i++)
             Console.WriteLine($"cycles: {ParseDecimal(),5:0.00} ");
    }
    private static ulong GetCyclesPerSeond()
    {
        Rdtsc.Init();
    
        var sw = Stopwatch.StartNew();
        var startms = Rdtsc.TimestampP();
        do { } while (sw.ElapsedMilliseconds < 1000);
        var endms = Rdtsc.TimestampP();
    
        return endms - startms;
    }
    
    private static double ParseDecimal()
    {
         var decStr = "-49823174320.9293800";
  
         var mincycles = ulong.MaxValue;
         var testDuration = 10000000000UL;
         var testCycles = 0UL;
         var minIterations = 100;
         var pos = 0;
         var startTest = Rdtsc.TimestampP();
         do
         {
             var start = Rdtsc.TimestampP();
             for (var j = 0; j < minIterations; j++) decimal.Parse(decStr);
             var end = Rdtsc.TimestampP();
             var cycles = end - start;
             if (cycles <= mincycles) mincycles = cycles;
             testCycles = Rdtsc.TimestampP() - startTest;
         } while (testCycles < testDuration);
         return mincycles / (double)minIterations;
     }
