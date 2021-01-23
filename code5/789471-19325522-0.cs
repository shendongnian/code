    // GET /Products(1)/Supplier
    public Supplier GetSupplier([FromODataUri] int key)
    {
    	var context = new ExampleContext();
        Product product = context.EF_Products.FirstOrDefault(p => p.ID == key);
        if (product == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        return product.Supplier;
    }
