    string insert = "INSERT INTO [Table] ([Username], [Password]) VALUES (@Username, @Password);";
    using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
         using(SqlCommand command = new SqlCommand(insert, connection))
         {
              connection.Open();
              command.Parameters.AddWithValue("@Username", username);
              command.Parameters.AddWithValue("@Password", password);
              command.ExecuteNonQuery();
         }
