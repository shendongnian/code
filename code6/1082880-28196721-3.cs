    TrackerContext _db = new TrackerContext();
    public ActionResult Index()
    {
        var assetList =_db.INV_Assets.ToList();     
        return View(assetList);
    }
