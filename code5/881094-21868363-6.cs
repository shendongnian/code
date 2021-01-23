    using System.Net.Http;
    
    // ...
    
    public async Task<String> FileToBase64(String filePath)
    {
        using (var client = new HttpClient())
        using (var response = await client.GetAsync(filePath))
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            return string.Empty;
            // use stream.ReadAsync
        }
    }
