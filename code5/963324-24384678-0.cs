    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            this.Configuration.LazyLoadingEnabled = true; 
        }
    }
