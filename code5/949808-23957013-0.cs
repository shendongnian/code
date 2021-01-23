    sqlCode = "SELECT * FROM [db].[dbo].[TablePDFTest] WHERE [name] = @name AND [ssn3] =@ssn3";
    
    using (SqlCommand command = new SqlCommand(sqlCode, Conn))
    {
          //command.CommandType = CommandType.Text;
          command.Parameters.AddWithValue("name", nameE);
          command.Parameters.AddWithValue("ssn3", c);
    
          using (reader = command.ExecuteReader())
          {
            // some action goes here...
          }
     }
