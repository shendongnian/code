    public class Database
    {
        private string _connectionString;
        // Pass the datasource through the constructor.
        public Database(string datasource)
        {
            _connectionString = "Data Source: " + datasource;
        }
        public void InsertField(string table, string field, object value)
        {
            using (var conn = new SQLiteConnection(_connectionString)) {
                string sql = String.Format("INSERT INTO {0} ({1}) VALUES (@1)",
                                           table, field);
                var command = new SQLiteCommand(sql, conn);
                command.Parameters.AddWithValue("@1", value);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
