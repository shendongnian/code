    [HttpPost]
    public ActionResult Create(Song songToCreate)
    {
        try
        {
            db.Songs.Add(songToCreate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            SetGenreViewBag();
            return View();
        }
    }
