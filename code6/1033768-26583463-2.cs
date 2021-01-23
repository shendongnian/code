    [ActionName("Search")]
    public IEnumerable<Movie> GetMovieBySearchParameter(string searchstr)
    {
         var cacheKey = "movies" + searchstr;
         var movies = GetFromCache<IEnumerable<Movie>>(cacheKey, () => { 
         // load list of movies 
         // this line will be evaluated only if the list of movies does not exist in cache
        	  return context.Movies.Where(x => x.Name == searchstr).ToList(); 
         });
         return movies;
    }
