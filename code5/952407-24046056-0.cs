        public ActionResult Index()
        {
            Queue<Movie> movies = new Queue<Movie>();
            movies.Enqueue(db.Movies.Single(m => m.Title == "Flash Gordon"));
            movies.Enqueue(db.Movies.Single(m => m.Title == "Star Wars"));
            return View( "Movie/Index", movies );
        }
