    [HttpGet]
    public HttpResponseMessage Test()
    {
        var stream = new MemoryStream();
        // ...
        // stream.Write(...);
        // ...
        stream.Position = 0;
        var response = Request.CreateResponse(HttpStatus.Ok);
        response.Content = new StreamContent(stream);
        return response;
    }
