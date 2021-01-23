    public class MoviesList
    {
        public List<Movie> Movies;
        public MoviesList()
        {
            Movies=new List<Movie>();
        }
        public void Add(Movie movie)
        {
            var highestId = Movies.Any() ? Movies.Select(x => x.Id).Max():1;
            movie.Id = highestId + 1;
            Movies.Add(movie);
        }
    }
