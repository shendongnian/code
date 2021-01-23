    public HttpResponseMessage Get(string id)
    {
        // Your logic here before redirection
        var response = Request.CreateResponse(HttpStatusCode.Moved);
        response.Headers.Location = new Uri("http://www.google.com");
        return response;
    }
