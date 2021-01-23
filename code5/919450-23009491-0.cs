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
         
        }
        return View(movies); //
        }
