    public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext()
                : base("DefaultConnection")
            {
            }
    
            protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<User>().ToTable("Users");
                (include all mappings)...
            }
        }
