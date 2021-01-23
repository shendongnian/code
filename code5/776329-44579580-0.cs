    private static void TestPerformance2()
    {
        var buffer = new StringBuilder[BufferSize];
        // Initialize each item of the array.  This is no different than what
        // unsafe struct is.
        for (int i = 0; i < BufferSize; i++)
        {
            buffer[i] = new StringBuilder(256);
        }
        GC.Collect(2);
        Stopwatch stopWatch = new Stopwatch();
        var initialCollectionCounts = new int[] { GC.CollectionCount(0), GC.CollectionCount(1), GC.CollectionCount(2) };
        stopWatch.Reset();
        stopWatch.Start();
        for (int i = 0; i < LoopCount; i++)
        {
            buffer[i % BufferSize].Clear(); // Or use .Length = 0;, which is what the Clear() method does internally.
            buffer[i % BufferSize].AppendFormat("{0}", i);
        }
        stopWatch.Stop();
        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
            typeof(StringBuilder).Name.PadRight(20),
            stopWatch.ElapsedMilliseconds,
            (GC.CollectionCount(0) - initialCollectionCounts[0]),
            (GC.CollectionCount(1) - initialCollectionCounts[1]),
            (GC.CollectionCount(2) - initialCollectionCounts[2])
        );
    }
