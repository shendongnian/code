      using(OleDbConnection connection = new OleDbConnection())
      {
        connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sim\Desktop\Web.accdb";
        connection.Open();
         OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        string query = "UPDATE [Registration] SET [State] = 'YES' WHERE [Authentication] = @authentication and [Email] = @email;";
        command.Parameters.AddWithValue("@authentication", TextBox2.Text);
        command.Parameters.AddWithValue("@email", TextBox1.Text);
        command.ExecuteNonQuery();
        connection.close();
      }
