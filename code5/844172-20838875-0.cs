    public ActionResult Index()
    {
        var genres = db.Genres.Include(x => x.Albums).ToList();
        return View(genres);
    }
