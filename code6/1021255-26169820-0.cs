    for (int z = 0; z < 5; z++)
    {
        int iterations = 15000;
        Stopwatch s = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)        
            Thread.Sleep(1);        
        s.Stop();
        Console.WriteLine("#{0}:Elapsed (for): {1:#,0}ms", z, ((double)s.ElapsedTicks / (double)Stopwatch.Frequency) * 1000);
        var options = new ParallelOptions() { MaxDegreeOfParallelism = 1 };
        s = Stopwatch.StartNew();
        Parallel.For(0, iterations, options, (i) => Thread.Sleep(1));
        s.Stop();
        Console.WriteLine("#{0}: Elapsed (parallel): {1:#,0}ms", z, ((double)s.ElapsedTicks / (double)Stopwatch.Frequency) * 1000);
    }
