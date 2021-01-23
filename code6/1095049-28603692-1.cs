    public ActionResult Index(int id)
    {
        var model = new IndexViewModel();
        using (var db = new ProductDB())
        {
           model.Products = (from p in db.Products
                             orderby p.ProductName
                             select new IndexViewModel.InfoProduct
                             {
                                 ProductName = p.ProductName,
                             }).ToList();
           return View(model);
        }
    }
