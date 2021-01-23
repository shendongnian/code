    public async Task<HomeInfo> GetHomeInfoAsync(DateTime timestamp)
    {
        using (var client = CreateDocumentServiceClient())
        {
            await client.BeginGetHomeInfoAsync(timestamp);
        }
    }
