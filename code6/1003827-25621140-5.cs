    public class MyContext : DbContext
    {
       ...
       public DbSet<A> As { get; set; }
       protected override void OnModelCreating( DbModelBuilder modelBuilder )
       {
          modelBuilder.Ignore<B>();
       }
    }
