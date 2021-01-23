    public static class DataAccessLayer
    {
        // Single connection string that all connections use
        private static readonly string _connectionString = "server=(local);integrated security=true;";
        
        // Stores that last observed connection if when opening a connection
        // NOTE: Using an object so that the Volatile methods will work
        private static object _lastErrorConnectionId = Guid.Empty;
        public static SqlConnection GetOpenedConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(_connectionString);
                connection.Open();
                return connection;
            }
            catch (SqlException ex)
            {
                // Did the connection open get to the point of creating an internal connection?
                if (ex.ClientConnectionId != Guid.Empty)
                {
                    // Verify that the connection id is something new
                    var lastId = (Guid)Volatile.Read(ref _lastErrorConnectionId);
                    if (ex.ClientConnectionId != lastId)
                    {
                        // New error, save id and fall-through to re-throw
                        // NOTE: There is a small timing window here where multiple threads could end up switching this between
                        //       a duplicated id and a new id. Since this is unlikely and will only cause a few additional exceptions to be
                        //       thrown\logged, there isn't a large need for a lock here.
                        Volatile.Write(ref _lastErrorConnectionId, (object)ex.ClientConnectionId);
                    }
                    else
                    {
                        // Duplicate error
                        throw new DuplicatedConnectionOpenException(_connectionString, ex);
                    }
                }
                // If we are here, then this is a new exception
                throw;
            }
        }
    }
    public class DuplicatedConnectionOpenException : Exception
    {
        public string ConnectionString { get; private set; }
        internal DuplicatedConnectionOpenException(string connectionString, SqlException innerException)
            : base("Hit the connection pool block-out period and a duplicated SqlException was thrown", innerException)
        {
            ConnectionString = connectionString;
        }
    }
