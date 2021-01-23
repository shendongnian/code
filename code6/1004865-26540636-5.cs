    public JsonResult GetMarketModels(string strReleaseID)
    {
        int releaseID = int.Parse(strReleaseID);
        var data = db.MarketModels.Where(t => t.ReleaseID == releaseID).ToList();
        return Json(data, JsonRequestBehavior.AllowGet);
    }
