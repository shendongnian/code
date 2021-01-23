    public async Task<string> SendDataAsync(string url)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync();
        return response.Content.ReadAsStringAsync();
    }
