    // GET: /Viewer/
    public ActionResult Index()
    {
        var result = db.Items.Select(i => i.GeoName).Distinct().OrderBy(n => n);
        return View(result);
    }
