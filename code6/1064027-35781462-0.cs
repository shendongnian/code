        [EnableQuery]
        [ODataRoute("Suppliers({key})/Products")]
        public IQueryable<Product> GetProductsForSupplier([FromODataUri] int key)
        {
            ...
        }
