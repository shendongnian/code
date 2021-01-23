    public class MyContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Entity<Person>().Property(p => p.Name).IsRequired();
        }
        // other members
    }
