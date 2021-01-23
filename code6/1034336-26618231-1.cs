    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseNamedEntity>().ToTable("MyTable");
            modelBuilder.Entity<Group>().Map(m => m.Requires("IsGroup")
                        .HasValue(true));
            modelBuilder.Entity<User>().Map(m => m.Requires("IsGroup")
                        .HasValue(false));
        }
        public DbSet<BaseNamedEntity> BaseNamedEntities { get; set; }
    }
