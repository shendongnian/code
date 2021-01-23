    public class YourContext : DbContext
    {
        //...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // Configure the primary key for the Partner
           modelBuilder.Entity<Partner>().HasKey(t => t.ID);
    
           // Map one-to-zero or one relationship
           modelBuilder.Entity<Partner>()
          .HasRequired(t => t.BinarParent )
          .WithOptional(t => t.Sponsor);
        }
        //...
    }
