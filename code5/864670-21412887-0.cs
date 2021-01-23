    public class Database
    {
        private string _datasource;
        private string _table;
        private string _field;
        private string _values;
        private SQLiteConnection _connection;
        public void ConnecttoDB(string datasource)
        {
            _datasource = datasource;
            _connection = new SQLiteConnection();
            _connection.ConnectionString = "Data Source: " + _datasource;
            _connection.Open();
        }
        public void InsertField(string table, string field, string values)
        {
            SQLiteCommand command = new SQLiteCommand(_connection);
            _table = table;
            _field = field;
            _values = values;
            String.Format("INSERT INTO {0} {1} VALUES{2}", _table, _field, _values);
        }
    }
