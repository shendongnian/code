    public class EFDbContext : DbContext
    {
       protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Class1>().Property(object => object.Rate).HasPrecision(20,15);
    
           base.OnModelCreating(modelBuilder);
       }
    }
