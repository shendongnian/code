    public class MoviesList
    {
        public List<Movie> Movies;
    
        public MoviesList()
        {
            Movies = new List<Movie>();
        }
    
        public void RemoveAndChange(Movie movie)
        {
            this.Movies.RemoveAll(x => x.Id == movie.Id);
            this.Movies.ForEach((x) => { if (x.Id > movie.Id) x.Id = x.Id - 1; });
        }
    }
