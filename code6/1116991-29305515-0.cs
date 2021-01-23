    private async Task<string> GetToken(string Username, string IpAddress)
    {
       string result = string.Empty;
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(SSOApiUri);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await client.GetAsync("api/yourcustomobjects");
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<GetSSOTokenResponse>(data);
            result = token.Token;
        }
        return result;
    }
