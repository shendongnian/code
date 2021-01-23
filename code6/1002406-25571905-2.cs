    public class MyService : IMyService
    {
        private readonly IDbContextFactory<BlogDb> blogContextFactory;
        public MyService(IDbContextFactory<BlogDb> blogContextFactory)
        {
            this.blogContextFactory = blogContextFactory;
        }
    
        public void CreateBlog(FormCollection formStuff) {};
    
        public void UpdateBlog() {};
    }
