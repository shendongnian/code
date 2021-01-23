    public sealed class MyMySqlConnection : DbConnection, IConnection
    {
        public MyMySqlConnection(MySqlConnection underlyingConnection)
        {
            UnderlyingConnection = underlyingConnection;
        }
        public MySqlConnection UnderlyingConnection
        {
            get;
            private set;
        }
        public override void Open()
        {
            UnderlyingConnection.Open();
        }
        // ...
