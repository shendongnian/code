    [HttpPost]
    public ActionResult Create(Song songToCreate)
    {
        try
        {
            db.Songs.Add(songToCreate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
