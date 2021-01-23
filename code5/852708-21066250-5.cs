    public ActionResult Create(int ResidentID)
    {
        var model = db.Residents.Where(r => r.ResidentID == ResidentID)
                    .Select(r => new CreateLogViewModel
                    {
                        ResidentID = r.ResidentID,
                        PFName = r.PFName,
                        PLName = r.PLName
                        // other properties
                    });
        return View(model);
    }
