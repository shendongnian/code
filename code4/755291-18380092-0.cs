    public interface IService
    {
         T Execute<T>(Func<IDbConnection, T> query);
         void Execute(Action<IDbConnection> query);
    }
    public sealed class Service : IService
    {
        private readonly string _connectionString;
        
        public Service(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        private IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            
            return connection;
        }
        
        public T Execute<T>(Func<IDbConnection, T> query)
        {
            using (var connection = CreateConnection())
            {
                return query(connection);
            }
        }
        public void Execute(Action<IDbConnection> query)
        {
            using (var connection = CreateConnection())
            {
                query(connection);
            }
        }
    }
