    public ActionResult Create(int ResidentID)
    {
        var resident = db.Residents.Find(ResidentID);
        var nl = new NewLog
        {
            ResidentID = ResidentID,
            PFName = resident.PFName,
            PLName = resident.PLName,
            Comment = string.Empty,
        };
        return View(nl);
    }
