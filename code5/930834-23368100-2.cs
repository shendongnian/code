    public List<Product> ListAll()
    {
      List<Product> products = db.Products
          .Where(p => p.Visible == true)
          .OrderBy(p => p.Name)
          . AsEnumerable() // or .ToList()
          .Select(p => new Product
          {
              ProductId = p.ProductId,
              Name = p.Name,
              ...
          })
          .ToList();
