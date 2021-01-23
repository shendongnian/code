    private async void GetString()
    {
        var str = await Login("http://www.google.com");
    }
    public async Task<string> Login(string apiAddress)
    {
        using (var client = new HttpClient())        
            return await client.GetStringAsync(apiAddress);
    }
