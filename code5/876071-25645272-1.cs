    [HttpPost]
    public async Task<string> SendMessage()
    {
           byte[] arrBytes = await Request.Content.ReadAsByteArrayAsync();
           return "";
    }
