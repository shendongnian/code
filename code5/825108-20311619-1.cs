    public ActionResult Index()
    {
            var model = new List<Product> { new Product { Id = 1, Name = "name" }, new Product { Id = 2 Name = "name2"} };
            return View(model);
    }
