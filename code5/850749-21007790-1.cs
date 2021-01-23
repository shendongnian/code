    public async Task<HttpResponseMessage> Get()
    {
        var request = WebRequest.Create("http://google.com");
        using (var response = await request.GetResponseAsync())
        using (var stream = response.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            string responseContent = reader.ReadToEnd();
            return Request.CreateResponse(HttpStatusCode.OK, responseContent);
        }
    }
