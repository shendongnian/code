    public class MyController : Controller
    {
        private readonly IDbContextFactory<BlogDb> blogContextFactory;
        public MyController(IDbContextFactory<BlogDb> blogContextFactory)
        {
            this.blogContextFactory = blogContextFactory;
        }
    }
    
