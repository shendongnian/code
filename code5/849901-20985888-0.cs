    public ActionResult Index(int id, int? siteID)
    {
        if (siteID.HasValue)
            return SetSite(id, siteID);
        return null;
    }
    
    
    //Second action
    public ActionResult SetSite(int id, int siteID)
    {
        return null;
    }
