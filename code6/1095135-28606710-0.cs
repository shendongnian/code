    //first DbContext
    namespace MultiDataContextMigrations.Models
    {
    public class DataContext : DbContext
    {
     public DataContext()
     : base("DefaultConnection")
     {
     
     }
     
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
     //TODO:Define mapping
     }
     
     public DbSet Users { get; set; }
     public DbSet Orders { get; set; }
    }
    }
    //second DbContext
    namespace MultiDataContextMigrations.Models
    {
    public class UserDataContext : DbContext
    {
     public UserDataContext():base("DefaultConnection")
     {
     }
     
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
     {
     //TODO:Define mapping
     }
     
     public DbSet Users { get; set; }
     public DbSet Roles { get; set; }
    }
    }
