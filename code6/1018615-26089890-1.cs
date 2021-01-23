    public T GetAsT<T> (HttpRequestMessage request)
    {
        HttpResponseMessage apiCall = Client.SendAsync(request).Result;
        string data = apiCall.Content.ReadAsStringAsync().Result;
        return JsonConvert.DeserializeObject<T>(data);
    }
