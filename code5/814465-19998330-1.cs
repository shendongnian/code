    class DatabaseAccessLayer
    {
        private readonly string connectionString;
        private SqlConnection connection;
        public DatabaseAccessLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool CreateDbConnection() 
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                return false;
            }
        }
    
        // Add other methods to interact with the database
    }
