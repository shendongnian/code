    HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Index(IndexViewModel model)
    {
       string name = model.NewItem.Name;
    }
