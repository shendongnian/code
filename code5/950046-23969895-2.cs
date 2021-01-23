    private Task GetAllCandidates(List<int> values)
    {
        Interlocked.Increment(ref _count);
        var tasks = Enumerable.Range(1, values.Count - 1).Reverse().Select(i =>
        {
            //Do work and calculations
            return Task.Factory.StartNew(() => GetAllCandidatePowers(newPowers));
        });
        return Task.WhenAll(tasks);
    } 
