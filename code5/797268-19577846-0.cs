    public Product Get(int id) 
    {
        Product p = _GetProduct(id);
        if (p == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        return p;
    }
