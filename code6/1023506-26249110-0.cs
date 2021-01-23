    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        : base("BlogLibrary2")
        {
        }
            public DbSet<Post> posts { get; set; }
            public DbSet<Comment> comments { get; set; }
            public DbSet<Category> categories { get; set; } 
    }
