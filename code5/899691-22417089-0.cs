    async void Main()
    {
        var result = await GetTextAsync("https://www.google.com");
        Console.Write(result.Length);
    }
    
    public async Task<string> GetTextAsync(string url){
        var result = await WebRequest.Create(url).GetResponseAsync();
        using (var stream = result.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            return await reader.ReadToEndAsync();
        }
    }
