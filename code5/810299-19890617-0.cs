    public ActionResult Index()
    {
        ViewBag.Files = db.MyObjects.Where(x => x.family == "Web").ToList();
        return View();
    }
