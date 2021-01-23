    async Task DownloadAndSaveAsync(string url, string filePath)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        
        // Was the request successful?
        if (response == null || !response.IsSuccessStatusCode) return;
        
        using (var file = File.Create(filePath))
        {
            await response.Content.CopyToAsync(file);
        }
    }
