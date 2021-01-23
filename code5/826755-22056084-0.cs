    public partial class MyDataBaseContext : DbContext
    {
        public MyDataBaseContext (string ConnectionString)
            : base(ConnectionString)
        {
        }
    }
