        public class DbContext: DbContext
    {
       public DbContext()
       {
          Configuration.ProxyCreationEnabled = false;
       }
    }
