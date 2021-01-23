    public abstract class MyDbContextBase : DbContext, IMyDbContext
    {
          public IDbSet<Users> Users {get; set;}
          public IDbSet<Widgets> Widgets {get; set;}
    }
