    public ActionResult Index()
    {
        var viewModel = new SomeViewModel();
        return View(viewModel);
    }
    public ActionResult DataOne()
    {
       var data =wcfProxy.Function1();
       return JSON(data,, JsonRequestBehavior.AllowGet);
    }
    ...
