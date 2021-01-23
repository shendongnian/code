    public class NewsRepository  : INewsRepository 
    {
        private YourDbContext db = null;
     
        public List<NewsList> NewsList
        {
            return this.db.NewsList.ToList();
        }
    
        public NewsRepository()
        {
            this.db = new NewsRepository();
        }
    }
    
    public class YourDbContext : DbContext
    {
        public DbSet<NewsList> NewsList {get; set;}
    }
