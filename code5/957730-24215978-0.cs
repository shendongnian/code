      public bool TruncateTable(string connectionString, string schema, string tableName) {
            var statement = "TRUNCATE TABLE [{0}].[{1}] ;";
            statement = string.Format(statement, schema, tableName);
            return ExecuteSqlStatement(connectionString, statement);
        }
        public bool DeleteAllEntriesTable(string connectionString, string schema, string tableName) {
            var statement = "DELETE FROM [{0}].[{1}] ;";
            statement = string.Format(statement, schema, tableName);
            return ExecuteSqlStatement(connectionString, statement);
        }
        public bool ExecuteSqlStatement(string connectionString, string statement, bool suppressErrors = false) {
            int rowsAffected;
            using (var sqlConnection = new SqlConnection(connectionString)) {
                using (var sqlCommand = new SqlCommand(statement, sqlConnection)) {
                    try {
                        sqlConnection.Open();
                        rowsAffected = sqlCommand.ExecuteNonQuery(); // potential use
                    }
                    catch (Exception ex) {
                        if (!suppressErrors) {
                         // YOUR ERROR HANDLER HERE
                        }
                        
                        return false;
                    }
                }
            }
            return true;
    
