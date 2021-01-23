    public class YourContext : DbContext
    {
        //...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // Configure the primary key for the Partner
           modelBuilder.Entity<Partner>().HasKey(t => t.ID);
    
           // Map one-to-many relationship
           modelBuilder.Entity<Partner>()
                .HasMany(p => p.Childs)
                .WithOptional(p => p.BinarParent);
            modelBuilder.Entity<Partner>()
                .HasOptional(t => t.Sponsor)
                .WithOptionalDependent()
                .Map(t => t.MapKey("FK_Sponsor_Id"))
        }
        //...
    }
