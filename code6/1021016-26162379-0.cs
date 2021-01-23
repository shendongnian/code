    [Route("/api/projectApi/products")]
    [ResponseType(typeof(IEnumerable<Product>))]
    public IHttpActionResult Get(string search, int max)
    { ...
    }
