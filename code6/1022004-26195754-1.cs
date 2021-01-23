    using System.Data.Entity;
 
    namespace MSSQL_EFCF.Classes
    {
      public class DataAccess : DbContext
      {
        public DataAccess() : base("myConnectionString")
        {}
 
        public DbSet<MyTableObject> MyObjects { get; set; }
 
      }
    }
