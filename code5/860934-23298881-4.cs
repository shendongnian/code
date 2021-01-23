    public partial class MyModelContainer
    {
        public MyModelContainer(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {
            // you can other stuff here if you need to, but don't have to for this example
        }
    }
