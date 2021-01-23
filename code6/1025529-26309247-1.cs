    async Task<string> GetStringAsync(HttpClient client,string url, int retries)
    {
        Task<string> task = null;
        for (int i = 0; i < retries; i++)
        {
            try
            {
                task = client.GetStringAsync(url);
                await task;
                break;
            }
            catch
            {
                // handle
            }
        }
        
        return await task;
    }
