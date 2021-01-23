        public class MovieRepository
        {
            private readonly MovieEntities context;
    
            public MovieRepository(MovieEntities context)
            {
                this.context = context;
            }
        }
