    public class Context : DbContext
    {
        public DbSet<A> As { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<B>().HasMany(b => b.Cees).WithMany(); // <-- THE SOLUTION
            base.OnModelCreating(modelBuilder);
        }
        public Context(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
