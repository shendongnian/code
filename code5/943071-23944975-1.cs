    public class BlogContext : DbContext
    {
        public BlogContext() : base("BlogContextConnectionStringName") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
