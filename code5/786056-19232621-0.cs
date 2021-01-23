    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionProvider.ConnectionString(databaseName)))
        {
            using (SqlCommand command = new SqlCommand())
            {
    
                if (sqlConnection.State != System.Data.ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
                //command.configure etc...
                command.ExecuteNonQuery();
    
            }
        }
    }
    catch (SqlException ex)
    {
        //retry
    }
    catch (Exception ex)
    {
        //something else went wrong ... fix it 
    }
