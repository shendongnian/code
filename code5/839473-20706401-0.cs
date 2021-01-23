    public ActionResult Index()    
    {
        var dbContext = new MovieDBContext();
        var movieList= dbContext .GetMoviesList();
        return View(movieList);
    }
