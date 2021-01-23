    [HttpGet]
    public HttpResponseMessage Test()
    {
        var stream = new MemoryStream();
        // ...
        // stream.Write(...);
        // ...
        stream.Position = 0;
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StreamContent(stream);
        return response;
    }
