    public class BloggingContext : DbContext
    {
        public BloggingContext()
            : base(@"Data Source=(localdb)\v11.0;Initial Catalog=CodeFirstNewDatabaseSample.BloggingContext;Integrated Security=True")
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
