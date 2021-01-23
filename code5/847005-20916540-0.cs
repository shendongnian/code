    public HttpResponseMessage Get()
    {
        return this.Request.CreateResponse(
            HttpStatusCode.OK,
            new { Message = "Hello", Value = 123 });
    } 
