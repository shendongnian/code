    [HttpGet]
    public ActionResult Index()
    {          
    	var schedules = db.Schedules.Include(s => s.Movie)
    			.OrderByDescending(s => s.Movie.MovieName)
    			.ToList();
    	return View(schedules);
    }
    
    [HttpGet]
    public ActionResult Movie(int id)
    {
    	//return ("Clicked");
    	var schedule = (from s in db.Schedules
    					 orderby s.ShowDate
    					 select s).SingleOrDefault();
    	return View(schedule);
    }
