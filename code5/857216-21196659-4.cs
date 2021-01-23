    public static List<movies> GetAll(this IEnumerable<movie> movie, ref moviescontext ctx)
    {
        var movies= ctx.movie
    
                             .Select(s => new movies
                             {
                                 MovieId= s.MovieID,
                                 MovieName = s.MovieName,
    
                             }).ToList();
                var movieCollection = new MovieCollection();
                movieCollection.AddRange(movies);
    
        return movieCollection;
    }
