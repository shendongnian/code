    public async Task<HttpResponseMessage> PostFile(string a, string b)
    {
         var requestStream = await Request.Content.ReadAsStreamAsync();
      ...
    }
