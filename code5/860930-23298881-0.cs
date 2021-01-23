    public partial class MyModelContainer
    {
        public MyModelContainer(SqlConnection sqlConnection, bool contextOwnsConnection)
            : base(sqlConnection, contextOwnsConnection)
        {
            // you can other stuff here if you need to, but don't have to for this example
        }
    }
