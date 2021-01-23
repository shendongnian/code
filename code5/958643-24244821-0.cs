        public class MovieRepository
        {
            private readonly MovieEntities context;
    
            public MovieRepository()
            {
                this.context = new MovieEntities();
            }
        }
