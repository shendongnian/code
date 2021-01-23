    private static SqlDatabaseClient CreateClient(int Id)
    {
        Int32 returnId = 0;
        try
        {
          using(MySqlConnection connection = new MySqlConnection(GenerateConnectionString()))
          {
            connection.Open();
            
            if(connection.State == ConnectionState.Open)
            {
               returnId = Id;
            }
            
          }
        }
        catch(Exception exception)
        {
           Console.Write(ex.Message);
        }
        finally
        {
            if(connection.State == ConnectionState.Open)
            {
               connection.Close();
            }
        }
        return returnId;
    }
