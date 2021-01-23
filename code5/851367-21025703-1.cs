    public ActionResult Index()
    {
        myEntities db = new myEntities();
        var model = db.meetings.Include("users").ToList();
        return View(model);
    }
