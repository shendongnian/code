    public IEnumerable<Product> GetAvailableProducts()
    {
      DataLoadOptions dlo = new DataLoadOptions();
      dlo.LoadWith<Product>(p => p.Category);
      db.LoadOptions = dlo;
      var ctx = new ProductsContext();
      return ctx.Products().ToList();
    }
