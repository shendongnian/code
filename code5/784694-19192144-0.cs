    public ActionResult Index()
    {
        var model = WidgetFactory.Create();
        model.SomeProperty = DataService.GetPropertyInfo();
        return View(model);
    }
