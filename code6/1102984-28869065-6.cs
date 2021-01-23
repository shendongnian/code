    public ActionResult Index()
    {
      var db = new MyDbContext();
      var model = db.Products.FirstOrDefault();
      return View(model);
    }
