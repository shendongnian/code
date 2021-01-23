    public partial class MyContext : DbContext
    {
      public MyContext(string connectionStringOrKey)
        : base(connectionStringOrKey)
      {
      }
    }
