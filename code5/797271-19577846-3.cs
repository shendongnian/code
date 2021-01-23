    public HttpResponseMessage Get()
    {
        Product product = new Product();
        // Serialize product in the response body
        return Request.CreateResponse(HttpStatusCode.OK, product);  
    }
