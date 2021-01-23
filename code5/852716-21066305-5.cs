    [HttpGet]
    public ActionResult Create(int residentID)
    {
        ViewBag.Resident = Db.Residents.Find(residentId);
        return View();
    }
