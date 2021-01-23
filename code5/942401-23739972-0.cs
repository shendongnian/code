    public static class ConnectionStrings
    {
        public const string MyConnectionStrinGoesHere = "My connection string goes here";
    }
 
    public class Context : DbContext
    {
        public Context(string connectionString) : base(connectionString) { }
    }
    public class ConnectionStringFromClassContext : Context
    {
        public ConnectionStringFromClassContext() : base(ConnectionStrings.MyConnectionStrinGoesHere)
        {
        
        }
    }
