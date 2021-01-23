    public ActionResult MoviesView()
    {
        var model = new IEnumerable<MvcMovie.Models.Movie>()
        { 
            new Movie("Casablanca"),
            new Movie("Fight Club"),
            new Movie("Finding Nemo")
        };
        return View(model);
    }
