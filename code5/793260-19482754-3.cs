    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
      public Configuration()
      {
        AutomaticMigrationsEnabled = false;
      }
    }
