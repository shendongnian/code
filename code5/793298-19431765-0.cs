    public async Task<bool> Init()
    {
        var series = Enumerable.Range(1, 5);
        Task.WhenAll(series.Select(i => DoWorkAsync(i)));
        return true;
    }
