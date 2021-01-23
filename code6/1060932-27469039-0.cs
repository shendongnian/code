    public class MyOwnReader : IDisposable
    {
        bool isDisposed = false;
        SqlConnection _connection;
        SqlCommand _command;
		// You can expose the whole command, or specific property of the command
        public SqlCommand Command
        {
            get
            {
                return _command;
            }
        }
        public MyOwnReader(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure; //example initialization
        }
        public void Dispose()
        {
            if (!isDisposed)
            {
                _connection.Dispose();
                _command.Dispose();
                isDisposed = true;
            }
        }
        public SqlDataReader ExecuteReader()
        {
            return _command.ExecuteReader();
        }
    }
