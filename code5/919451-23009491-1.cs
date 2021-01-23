       public ActionResult SearchIndex(string searchString)
      {
        var movies = from m in db.Movies
                     select m;
        if (!string.IsNullOrEmpty(searchString))
        {
            movies=movies.Where(s=>s.Title.StartsWith(searchString));
        }
        if(movies == null)
        {
         ViewData["NoMovies"] = "No Movies found";
         movies = from m in db.Movies
                     select m; // As your movie will be null or You can pass a new movies()
        }
        return View(movies); //
        }
