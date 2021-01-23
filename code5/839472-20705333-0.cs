      public ActionResult Index(){
        var context = new MovieDBContext();
        var allMovies = context.GetMoviesList();
        return View(allMovies);
      } 
