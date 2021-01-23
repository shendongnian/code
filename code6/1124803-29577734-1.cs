    public async Task<string> httpPOST(string url, FormUrlEncodedContent content)
    {
        var httpClient = new HttpClient(new HttpClientHandler());
        string resp = "";
        HttpResponseMessage response = new HttpResponseMessage();
        response = await httpClient.PostAsync(url, content);
        try
        {
            response.EnsureSuccessStatusCode();
            Task<string> getStringAsync = response.Content.ReadAsStringAsync();
            resp = await getStringAsync;
        }
        catch (HttpRequestException)
        {
            resp = "NO_INTERNET";
        }
            return resp;
    }
