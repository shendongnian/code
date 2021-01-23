    public ActionResult MoviesView()
    {
        var model = new List<MvcMovie.Models.Movie>()
        { 
            new Movie("Casablanca"),
            new Movie("Fight Club"),
            new Movie("Finding Nemo")
        };
        return View(model);
    }
