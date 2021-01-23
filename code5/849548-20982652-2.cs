    long Measure(int n,Action action)
    {
        action(); 
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < n; i++)
        {
            action();
        }
        return sw.ElapsedMilliseconds;
    }
