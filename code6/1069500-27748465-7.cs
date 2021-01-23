    public class BlogContext : DbContext
    {
        public BlogContext(string name)
            : base(name)
        {
        }
        public IDbSet<Blog> Blogs { get; set; }
        public IDbSet<Post> Posts { get; set; }
    }  
