    public HttpResponseMessage Get(int id) 
    {
        Product p = _GetProduct(id);
        if (p == null)
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
        return Request.CreateResponse(HttpStatusCode.OK, p);
    }
