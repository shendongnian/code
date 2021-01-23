    public ActionResult Index(string id)
    {
        ViewBag.Title = id;
        return View(new TestDataHelper(id));
    }
