    ProductsController : EntitySetController<Product, int>
    {
       /// <summary>
       /// Support for /Products(1)/BatchNumbers
       /// </summary>
       [Queryable]
       public IQueryable<BatchNumber> GetBatchNumberss([FromODataUri] int key)
       {
           return _db.Products.Where(p => p.ID == key).SelectMany(p => p.BatchNumbers);
       }
    }
