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
    	var schedules = (from s in db.Schedules
                         Where s.MovieId == id
    					 orderby s.ShowDate
    					 select s).ToList();
    	return View(schedules);
    }
