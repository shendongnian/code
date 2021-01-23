    [HttpGet]
    public ActionResult Create(int ResidentID)
    {
        ViewBag.Equipment = Db.Residents.Find(residentId);
        return View();
    }
