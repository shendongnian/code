    public ActionResult Index()
    {
       var model = new MyModel{ Name = User.Identity.Name };
       return View(model);
    }
