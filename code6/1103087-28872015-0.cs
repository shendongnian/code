    public async Task<string> SendDataAsync(string url)
    {
        var httpClient = new HttpClient();
        var response = httpClient.GetAsync();
        return response.Content.ReadAsStringAsync();
    }
