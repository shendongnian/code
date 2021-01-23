    var connection = new MySqlConnection(connectionString);
    try
    
    {
    
    
    connection.Open();
    
    var transaction = connection.BeginTransaction();
    
    MySqlCommand command = new MySqlCommand(sqlQuery, connection, transaction);
    MySqlDataReader dataReader = command.ExecuteReader(); 
    }
    catch (Exception)
            {
                throw;
            }
