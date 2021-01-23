    [ActionName("Search")]
    public IEnumerable<Movie> GetMovieBySearchParameter(string searchstr)
    {
         var cacheKey = "movies" + searchstr;
         var movies = GetFromCache<IEnumerable<Movie>>(cacheKey, () => {               
        	  return repository.GetMovies().OrderBy(c => c.MovieId).ToList(); 
         });
         return movies;
    }
