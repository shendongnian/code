    public class DbContextFactory : IDbContextFactory<BlogDb>
    {
        public BlogDb Create() 
        {
            return new BlogDb();
        }
    }
