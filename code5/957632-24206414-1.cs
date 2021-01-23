    public ActionResult Index(string id)
    {
        ViewBag.Title = sportName;
        return View(new TestDataHelper(sportName));
    }
