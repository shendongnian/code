    private void SubmitNote(string message)
    {
         // Ensure parameter isn't null.
         if(string.IsNullOrEmpty(message))
              return;
    
          // Our Insert Query:
          string insert = @"INSERT INTO [Notes] ([Username], [Date], [Message])
                                  VALUES (@Username, @Date, @Message);";
    
         // Define our Connection & Command:
         using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
              using(SqlCommand command =  new SqlCommand(insert, connection))
              {
                    // Open Connection
                    connection.Open();
    
                    // Define our Command (AddWithValue / Add Approach)
                    command.Parameters.Add("@Username", SqlDbType.VarChar, 50).Values = User.Identity.Name;
                    command.Parameters.AddWithValue("@Date", DateTime.Now);
                    command.Parameters.Add("@Message", SqlDbType.VarChar).Value = message;
                    
                    // Execute Query:
                    command.ExecuteNonQuery();
              }
    }
