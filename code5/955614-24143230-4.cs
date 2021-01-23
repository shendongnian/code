    public IEnumerable<Product> GetAvailableProducts()
    {
      var ctx = new ProductsContext();
      DataLoadOptions dlo = new DataLoadOptions();
      dlo.LoadWith<Product>(p => p.Category);
      ctx.LoadOptions = dlo;
      return ctx.Products().ToList();
    }
