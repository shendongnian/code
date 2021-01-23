    public ActionResult Index()
    {
        var eodBl = new EODAuditBL();
        return View(eodBl);
    }
    [ChildActionOnly]
    public ActionResult ListEODAuditBLs()
    {
        // look up from database
        var eodModel = db.EODAudits.ToList();
        return PartialView(eodModel);
    }
