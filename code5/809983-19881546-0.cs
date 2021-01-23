    public ActionResult Index()
    {
        List<MyObject> list = db.MyObjects.Where(x => x.family == "Web").ToList();
        ViewBag.Files =new SelectList(list,"Id","fileName)";
        return View();
    }
