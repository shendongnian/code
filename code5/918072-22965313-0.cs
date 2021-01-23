    public static TimeSpan Benchmark(Action action)
    {
        var sw = Stopwatch.StartNew();
        action();
        sw.Stop();
        return sw.Elapsed;
    }
    ...
    var timeTaken = Benchmark(() => /* run some code */)
