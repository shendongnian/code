    // TODO: Set your connection string based on whatever criteria you need.
                string connectionString = String.Empty;
    
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString))
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
    
                    using (var command = new SqlCommand("commandToExecute", connection))
                    {
                        var reader = command.ExecuteReader();
                        // Do whatever.
                    }
                }
