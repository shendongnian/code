    public partial class MyDatabaseEntities : DbContext
    {
        public MyDatabaseEntities(string connectionString)
            : base(connectionString)
        {
        }
    }
