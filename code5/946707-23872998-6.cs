    public static string BenchmarkMethod(Action method, int iterations)
    {
        var watch = new Stopwatch();
        var results = new List<TimeSpan>(iterations);
        for (int iteration = 0; iteration < iterations; iteration++)
        {
        watch.Start();
        method();
        watch.Stop();
        results.Add(watch.Elapsed);
        watch.Reset();
        }
    
        var builder = new StringBuilder();
        builder.Append("Method benchmarked: ");
        builder.Append(method.Method.ReflectedType);
        builder.Append(".");
        builder.AppendLine(method.Method.Name);
        builder.Append("Average time in ticks: ");
        builder.AppendLine(results.Average(t => t.Ticks).ToString());
        return builder.ToString();
    }
