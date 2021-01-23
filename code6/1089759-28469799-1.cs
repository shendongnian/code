    [HttpGet]
    public async Task<HttpResponseMessage> Get(int id)
    {
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        // ...
        await fs.CopyToAsync(streamToCopyTo)
        // ...
        return result;
    }
