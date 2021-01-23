    public async Task<int> GetSiteLengthAsync(string url) 
    {  
        HttpClient client = new HttpClient();               <= Sync  
        Task<string> download1 = client.GetStringAsync(url); <= Sync  
        string site1 = await download1;   <= Async (Another thread)
        return site1.Length;              <= Async (Another thread)
    }
