    public class EntityFrameworkContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Set> Set { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().Map<Lesson>(m => m.Requires("Type_ID").HasValue(1))
                .Map<Set>(m => m.Requires("Type_ID").HasValue(2));
        }
    }
