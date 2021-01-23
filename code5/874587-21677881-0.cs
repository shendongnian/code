    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BlogDetail BlogDetail { get; set; }
    }
    public class BlogDetail
    {
        public int Id { get; set; }
        public int PostCount { get; set; }
        public Blog Blog { get; set; }
    }
    public class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasOptional(b => b.BlogDetail).WithOptionalPrincipal(bd => bd.Blog);
        }
    }
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext db)
        {
            var blog1 =  new Blog { Name = "Blog 1", BlogDetail = new BlogDetail { PostCount = 10 } };
            var blog2 =  new Blog { Name = "Blog 2", BlogDetail = new BlogDetail { PostCount = 28 } };
            db.Blogs.AddRange(new List<Blog> { blog1, blog2 });
        }
    }
