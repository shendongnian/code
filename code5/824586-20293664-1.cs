    private void DoStuff()
    {
        const int ThreadsCount = 10000;
        var sw = Stopwatch.StartNew();
        int testVal = 0;
        for (int i = 0; i < ThreadsCount; ++i)
        {
            Interlocked.Increment(ref testVal);
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks);
        sw = Stopwatch.StartNew();
        testVal = 0;
        for (int i = 0; i < ThreadsCount; ++i)
        {
            var myThread = new Thread(() =>
            {
                Interlocked.Increment(ref testVal);
            });
            myThread.Start();
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedTicks);
    }
