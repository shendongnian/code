    async Task SyncToDatabase(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            DatabaseSyncer dbSyncer = new DatabaseSyncer();
            await dbSyncer.DeserializeAndUpdate();
            await Task.Delay(10, token); // after elapsed time re-run above code
        }
    }
