    [HttpPost]
    public async System.Threading.Tasks.Task<string> Post(HttpRequestMessage request)
    {
        string body = await request.Content.ReadAsStringAsync();
        return body;
    }
