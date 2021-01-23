    public ActionResult Index(int id)
    {
        var assetList =_db.INV_Assets.Where(s=>s.Location_Id==id).ToList();     
        return View(assetList);
    }
