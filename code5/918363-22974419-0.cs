    public PageResult<Product> Get(ODataQueryOptions<Product> options)
    {
        IQueryable results = options.ApplyTo(_products.AsQueryable());
    
        return new PageResult<Product>(
            results as IEnumerable<Product>, 
            Request.GetNextPageLink(), 
            Request.GetInlineCount());
    }
