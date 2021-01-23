    public ActionResult Create()
    {
        var model = new AssetViewModel();
        PopulateCategoryChoices(model);
        return View(model);
    }
