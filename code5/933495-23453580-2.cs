    [HttpGet]
    public ActionResult Detail(int MovieID)
    {
        //return ("Clicked");
        var schedule = (from s in db.Schedules
                         where s.MovieId==MovieId
                         orderby s.ShowDate
                         select s).FirstOrDefault();
        return View(schedule);
    }
