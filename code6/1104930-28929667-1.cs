    public partial class MyContext : DbContext
    {
      private static string GetConnectionString()
      {
      }
    
      public static MyConnection CreateMyContext()
      {
        return new MyContext(MyContext.GetConnectionString());
      }
    }
