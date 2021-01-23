    var container = new List<string>();
    var dbConnection = "...";
    var query = "SELECT [Message] FROM [db] WHERE [Message] = @Value";
    using(var connection = new SqlConnection(dbConnection))
    using(var command = new SqlCommand(query, connection))
    {
         connection.Open(); 
         command.Parameters.Add("@Value", SqlDbType.VarChar, max).Value = "Blah";    
         using(var reader = command.ExecuteReader())
             while(reader.Read())
             {
                  if(reader["Message"] != DBNull.Value)
                       container.Add(reader["Message"].ToString());
             }
    }
