    var results = new List<Result>();
    Parallel.For(0, 100, index =>
    {
        lock (results)
        {
            results.Add(Result.Create(...));
        }
    });
    results = results.Where(t => t.IsValid).ToList(); // NRE here due to t is null!
