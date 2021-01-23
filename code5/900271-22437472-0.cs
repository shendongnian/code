    var movies = new List<MvcMovie.Models.Movie>();
    foreach (var movie in db.Movies)
    {
        movies.Add(new MvcMovie.Models.Movie {
            Title = movie.Title,
            Year = movie.Year,
            Format = movie.Format
            //etc...
        });
    }
    
    return View(movies);
