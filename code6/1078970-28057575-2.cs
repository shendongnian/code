    class MoviesObject {
        public List<Movie> movies { get; set; }
    }
    List<Movie> movieList = new JavaScriptSerializer().
        Deserialize<MoviesObject>(json).movies;
