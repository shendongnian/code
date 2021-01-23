    public ActionResult Index()
    {
        var orders = db.Orders.Include(o => o.Product)
            .GroupBy(o => o.Product.Category.Name)
            .Select(cat => cat.FirstOrDefault());
        var products = db.Orders.Include(o => o.Product);
        return View(Tuple.Create(orders.ToList(), products.ToList()));
    }
