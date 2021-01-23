    public ActionResult Details(int id)
    {
        using (var db = new MainDatabaseEntities())
        {
            var anime = db.ANIME.Find(id);
            db.Entry(anime).Collection(a => a.GENRES).Load();
            return View(anime);             
        }
    }
