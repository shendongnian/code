    var results = new List<Result>();
    Parallel.For(0, 100, index =>
    {
        var result = Result.Create(...);
        lock (results)
        {
            results.Add(result);
        }
    });
    results = results.Where(t => t.IsValid).ToList(); // NRE here due to t is null!
