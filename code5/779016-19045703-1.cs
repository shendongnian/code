    static IEnumerable<double> Uniform(Random rng)
    {
        while (true)
            yield return rng.NextDouble();
    }
    static void Main(string[] args)
    {
        IScheduler scheduler = Scheduler.Default;
        var source = Uniform(new Random());
        ToObservableDelay(source, TimeSpan.FromSeconds, Scheduler.Default)
            .ForEachAsync(Console.WriteLine)
            .Wait();
    }
