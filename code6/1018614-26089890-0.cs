    public async Task<T> GetAsT<T> (HttpRequestMessage request)
    {
        HttpResponseMessage apiCall = await Client.SendAsync(request);
        string data = await apiCall.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(data);
    }
