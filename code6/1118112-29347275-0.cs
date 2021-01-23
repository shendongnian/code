    var results = new ConcurrentDictionary<string, string>();
    Parallel.ForEach(test,
        new ParallelOptions { MaxDegreeOfParallelism = 10 },
        pair =>
        {
            if (IsLoginSuccess(pair.Key, pair.Value))]
            {
                results[pair.Key] = pair.Value;
            }
        });
