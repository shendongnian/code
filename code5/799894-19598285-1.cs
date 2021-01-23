    public class MovieCollection
    {
        private Dictionary<string, Movie> movies = 
                   new Dictionary<string, string>(); 
        private Dictionary<int, string> moviesById = 
                   new Dictionary<int, string>();
        public MovieCollection()
        {
        }
        // Indexer to get movie by ID
        public Movie this[int index]  
        {
            string title = moviesById[index];
            return movies[title];
        }
    }
