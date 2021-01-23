    public List<Movie> LoadMovies()
    {
        // Need to get '_connectionString' from somewhere: probably best to pass it into the class constructor and store in a field member
        using (var db = new MoviesContext(_connectionString))
        {
            return db.Movies.AsNoTracking().ToList();
        }
    }
