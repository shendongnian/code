    public partial class YourContextClass: DbContext
    {
        public YourContextClass(string connectionString) : base(connectionString) 
        {
              Database.Connection.ConnectionString = connectionString; 
        }
    }
