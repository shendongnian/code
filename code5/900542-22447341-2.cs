    public async Task Post(HttpRequestMessage request)
    {
        string requestContent = await request.Content.ReadAsStringAsync();
        // use requestContent variable here
    }
