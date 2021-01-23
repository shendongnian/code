    public class MyAppContext : DbContext
    {
        public MyAppContext()
        {
            // hack to force the EntityFramework.SqlServer.dll to be copied when another project references this one
            var forceDllCopy = System.Data.Entity.SqlServer.SqlProviderServices;
        }
    }
