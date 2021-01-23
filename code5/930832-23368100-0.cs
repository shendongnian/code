    public List<Product> ListAll()
    {
      List<Product> products = db.Products
          .Where(p => p.Visible == true)
          .OrderBy(p => p.Name)
          .ToLis()  // materialize your query before the second projection
          .Select(p => new Product
          {
              ProductId = p.ProductId,
              Name = p.Name,
              ...
          })
          .ToList();
