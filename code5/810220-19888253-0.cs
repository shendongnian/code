    public ActionResult Index()
    {
        List<MyObject> list = db.MyObjects.Where(x => x.family == "Web").DistinctBy(x=> x.protocol).ToList();
        ViewBag.Files = new SelectList(list,"Id","protocol);
        return View();
    }
