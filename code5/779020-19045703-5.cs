    static IEnumerable<double> Uniform(Random rng)
    {
        while (true)
            yield return rng.NextDouble();
    }
    static void Main(string[] args)
    {
        var source = Uniform(new Random());
        Console.WriteLine("press any key to quit");
        using (var subscription = 
            ToObservableDelay(source, TimeSpan.FromSeconds, Scheduler.Default)
            .Subscribe(Console.WriteLine))
        {
            Console.ReadKey();
        }
    }
