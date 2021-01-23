    public async Task<HttpStatusCode> SendAsync(Data data)
    {
        string jsonData = string.Format("={0}", JsonConvert.SerializeObject(data));
        var content = new StringContent(
                jsonData,
                Encoding.UTF8,
                "application/x-www-form-urlencoded");
            HttpResponseMessage response = await _httpClient.PostAsync(_url, content);
            return response.StatusCode;
    }
