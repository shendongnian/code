    public async Task<string> httpPOST(string url, FormUrlEncodedContent content)
    {
        var httpClient = new HttpClient(new HttpClientHandler());
        string resp = "";
        HttpResponseMessage response = new HttpResponseMessage();
        httpClient.DefaultRequestHeaders.Add("X-LANGUAGE", lang);
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Tesco WindowsPhone");
        response = await httpClient.PostAsync(tesco_base_url + url, content);
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
