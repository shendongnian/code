    {
        IEnumerable<string> queryResults;
        bool useParallel = true;
        var strings = new List<string>();
        for (int i = 0; i < 2500000; i++)
            strings.Add(i.ToString());
        var stp = new Stopwatch();
        stp.Start();
        if (useParallel)
            queryResults = strings.AsParallel().Where(item => item.Contains("1")).ToList();
        else
            queryResults = strings.Where(item => item.Contains("1")).ToList();
        stp.Stop();
        Console.WriteLine("useParallel: {0}\r\nTime Elapsed: {1}", useParallel, stp.ElapsedMilliseconds);
    }
