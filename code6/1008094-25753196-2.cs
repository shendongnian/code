    public HttpResponseMessage GetString()
        {
        string s="Hello, world!";
        return Request.CreateResponse(HttpStatusCode.Ok, s);
        }
