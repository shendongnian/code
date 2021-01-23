    public class MyService : IMyService
    {
        private readonly IDbContextFactory<BlogDb> blogContextFactory;
        public MyService(IDbContextFactory<BlogDb> blogContextFactory)
        {
            this.blogContextFactory = blogContextFactory;
        }
    
        public void CreateBlog(FormCollection formStuff) {};
    
        public void UpdateBlog() {};
        public List<Blog> GetBlogs() {}; // Use List<T> or IQueryable<T> (this allows you to keep querying the database before it is hit)
    }
