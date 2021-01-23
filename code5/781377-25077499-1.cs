    public async Task<HttpResponseMessage> Post()
    {
        Stream requestStream = await this.Request.Content.ReadAsStreamAsync();
        byte[] byteArray = null;
        using (MemoryStream ms = new MemoryStream())
        {
            await requestStream.CopyToAsync(ms);
            byteArray = ms.ToArray();
        }
        .
        .
        .
        return Request.CreateResponse(HttpStatusCode.OK);
    }
