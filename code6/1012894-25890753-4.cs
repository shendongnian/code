    class Database
    {
        private string connString;
        public Database(string connString)
        {
            this.connString = connString;
        }
        private void CreateCommand(string queryString)
        {  
            using (SqlConnection sqlConnection = new SqlConnection(this.connString))
            {
                // etc.
            }
        }
    }
