    public static void Test()
    {
        var tasks = Enumerable.Repeat(int.MaxValue, 10000).Select(n => Task.Run(() => Compute(n)));
        var stopwatch = Stopwatch.StartNew();
        Task.WhenAll(tasks).Result.SelectMany(result => result).ToList();
        Console.WriteLine("Task.WhenAll - {0}", stopwatch.Elapsed);
        stopwatch.Restart();
        tasks.Select(t => t.Result).SelectMany(r => r).ToList();
        Console.WriteLine("Select - {0}", stopwatch.Elapsed);
    }
    private static List<int> Compute(int seed)
    {
        var results = new List<int>();
        for (int i = 0; i < 5000; i++)
        {
            results.Add(seed * i);
        }
        return results;
    }
