    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
      public BlogContext()
        : base("BlogConnection")
      {
      }
      public DbSet<Post> Posts { get; set; }
      public DbSet<Comment> Comments { get; set; }
    }
