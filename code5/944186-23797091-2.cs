    public class DatabaseContext : DbContext
    {
       // name="DBConnectionString" is the <connectionString -> name> from Web.config
       public DatabaseContext() : base("name=DBConnectionString") { }
    
       public DbSet<User> Users { get; set; }
       protected override void OnModelBinding(ModelBuilder modelBuilder)
       {
           // Define mappings
           modelBuilder.Entity<User>().ToTable("USERS");
           modelBuilder.Entity<User>().HasKey(x=>x.Id);
       }
    }
