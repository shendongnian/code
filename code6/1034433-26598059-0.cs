    async Task<string> GetResponseString(string text)
    {
        var httpClient = new HttpClient();
        var parameters = new Dictionary<string, string>();
        parameters["text"] = text;
        var response = await httpClient.PostAsync(BaseUri, new FormUrlEncodedContent(parameters));
        var contents = await response.Content.ReadAsStringAsync();
        return contents;
    }
