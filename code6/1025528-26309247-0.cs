    async Task<string> GetStringAsync(HttpClient client, string url, int retries)
    {
        string result = null;
        for (int i = 0; i < retries; i++)
        {
            try
            {
                result = await client.GetStringAsync(url);
                break;
            }
            catch
            {
                // log or handle
            }
        }
        
        return result;
    }
