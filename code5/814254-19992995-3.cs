    public ActionResult Index()
    {
        var model = new SomeViewModel();
        model.Employees = // ... fetch from database.
        model.Jobs = // ... fetch from database.
        return View(model);
    }
