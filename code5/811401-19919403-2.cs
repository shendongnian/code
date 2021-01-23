    public ActionResult Index()
    {
        TestViewModel model = new TestViewModel();
        model.WorkSections = BuildSelectList(workSections, m => m.ID, m => m.CodeSource);
        return View(model);
    }
