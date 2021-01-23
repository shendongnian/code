    private void DuplicateEmail()
    {
         if(string.IsNullOrEmpty(txtEmail))
             return;
    
         int row = 0;
         string query = @"SELECT * FROM [SomeTable] WHERE ([Email] = @Email);";
    
         using(SqlConnection connection = new SqlConnection(ConfigurationManager...))
              using(SqlCommand command = new SqlCommand(query, connection))
              {
                   connection.Open();
                   command.Parameters.AddWithValue("@Email", txtEmail.Text);
                   row = (Int32)command.ExecuteScalar();
                   
                   if(row == 1)
                   {
                       // Call alert.
                   }
               }
    }
    
