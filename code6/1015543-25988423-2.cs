    public ActionResult Index()
    {
        var model = new MyViewModel {
            Movies = db.Movies.ToList(),
            Students = db.Students.ToList()
        }
        return View(model);
    }
