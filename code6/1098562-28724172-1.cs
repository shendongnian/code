    var container = new List<int>();
    var dbConnection = "...";
    var query = "SELECT [prevHours] FROM [submissions] WHERE [projCat] = @Value";
    using(var connection = new SqlConnection(dbConnection))
    using(var command = new SqlCommand(query, connection))
    {
         connection.Open(); 
         command.Parameters.Add("@Value", SqlDbType.VarChar, max).Value = "Capacity";    
         using(var reader = command.ExecuteReader())
             while(reader.Read())
             {
                  if(reader["prevHours"] != DBNull.Value)
                       container.Add(Convert.ToInt32(reader["prevHours"]));
             }
    }
