    public class MyDbContext : IdentityDbContext<MyUser>
    {
      public MyDbContext()
        : base("TheNameOfTheConnectionString")
      {
      }
    }
