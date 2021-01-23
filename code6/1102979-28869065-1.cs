    public ActionResult Index()
    {
      var model = new IndexVM();
      using (var db = new MyDbContext())
      {
        // Assuming EF
        var dbProduct = db.Products.FirstOrDefault();
        // Even better performance:
        var dbProduct = db.Products
          // prevent lazy loading
          .Include(p => p.Description.Color)
          .FirstOrDefault()
          // prevent ef tracking with proxy objects
          .AsNoTracking();
        // can be automated with AutoMapper or other .Net Components
        ProductVM productVM = new ProductVM();
        productVM.Id = dbProduct.Id;
        // etc
        // Don't put logic in View:
        productVM.HasDescription = product.Description;
        if (productVM.HasDescription)
        {
           var descriptionVM = new DescriptionVM();
           // map values
           productVM.Description = descriptionVM;
        }
      
