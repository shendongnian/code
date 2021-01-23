    public class SqlServerFactoryWorker : IFactoryWorker
    {
        public IDbInterop CreateInterop( string connectionString )
        {
          return new MSSQLDbInterop(connectionString);       
        }
        public bool AcceptParameters( string providerName )
        {
           return providerName == "System.Data.SqlClient";
        }
    }
