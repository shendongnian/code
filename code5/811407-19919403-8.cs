    public ActionResult Index()
    {
        var workSections = // ... fetch from database
        TestViewModel model = new TestViewModel();
        model.WorkSections = BuildSelectList(workSections, m => m.ID, m => m.CodeSource);
        return View(model);
    }
