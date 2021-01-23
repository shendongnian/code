    [HttpGet]
    public HttpResponseMessage Test()
    {
        var stream = new MemoryStream();
        var response = Request.CreateResponse(HttpStatus.Ok);
        response.Content = new StreamContent(stream);
        // ...
        // stream.Write(...);
        // ...
        return response;
    }
