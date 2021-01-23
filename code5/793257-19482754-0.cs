    public class MyDbContext : DbDContext, IMyDbContext
    {
      public IDbSet<Users> Users {get; set;}
      public IDbSet<Widgets> Widgets {get; set;}
    }
    
    // Migrations are considered configured for MyDbContext because this class implementation exists.
    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
      public Configuration()
      {
        AutomaticMigrationsEnabled = false;
      }
    }
    
    // Declaring (and elsewhere registering) this DB initializer of type MyDbContext - but a DbMigrationsConfiguration already exists for that type.
    public class TestDatabaseInitializer : DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context) { }
    }
