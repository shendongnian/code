    public class MyDbContext : DbContext
    {
        public MyDbContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
