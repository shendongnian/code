    public ActionResult Index()
    {
        var model = WidgetFactory.Create();
        return View(model);
    }
