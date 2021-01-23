    public async Task Load()
    {
        await Task.WhenAll(GetAsync(1), GetAsync(2), GetAsync(3)).ConfigureAwait(false);
        // process data.
    }
