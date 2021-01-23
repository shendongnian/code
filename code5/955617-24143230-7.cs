    public IEnumerable<Product> GetAvailableProducts()
    {
      var ctx = new ProductsContext();
      return ctx.Products.Include("Category").ToList();
    }
