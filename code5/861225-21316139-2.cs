    public class GhettoDbWrapper
    {
        string connectionString;
        
        public GhettoDbWrapper(string serverInstanceName, string databaseName)
        {
            // Create connection string
        }
        
        public ExecuteGhettoDb(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSting))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Connection failed: ", ex.Exception);
            }
            catch (Exception ex)
            {
                // Ghetto throw the rest of them
                throw ex;
            }
        }
    }
