    private Task GetAllCandidates(List<int> values)
    {
        Interlocked.Increment(ref _count);
        List<Task> tasks = new List<Task>();
        for (var i = values.Count - 1; i >= 1; i--)
        {
            //Do work and calculations
            Task task = Task.Factory.StartNew(() => GetAllCandidatePowers(newPowers));
            tasks.Add(task);
        }
        return Task.WhenAll(tasks);
    }
