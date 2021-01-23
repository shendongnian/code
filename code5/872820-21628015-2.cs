    async Task UpdateUIAsync(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            await Dispatcher.Yield(DispatcherPriority.Background);
            var data = await GetDataAsync(token);
            // do the UI update (or ViewModel update)
            this.TextBlock.Text = "data " + data;
        }
    }
    async Task<int> GetDataAsync(CancellationToken token)
    {
        // simulate async data arrival
        await Task.Delay(10, token);
        return new Random(Environment.TickCount).Next(1, 100);
    }
