    public class Context : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(d => d.Id);
            modelBuilder.Entity<Person>()
                .Property(d => d.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Person>()
                .Property(d => d.SomeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
