    [HttpPost]
    public ActionResult Index(int MovieID)
    {
        //return ("Clicked");
        var schedules = (from s in db.Schedules
                         where s.MovieId==MovieId
                         orderby s.ShowDate
                         select s).ToList();
        return View(schedules);
    }
