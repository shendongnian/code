    string connectionString = @"Data Source=CEX-PC\SQLEXPRESS;Initial     
                         Catalog=inventorydatabase;Integrated Security=True";
                         SqlConnection con = new SqlConnection(connectionString);
    con.Open();
    string query = "INSERT INTO userdetail (username, password, position) VALUES(@username,@password,@val )";
    SqlCommand command = new SqlCommand(query, con);
    
    command.CommandType= CommandType.Text;
    command.Parameters.AddWithValue("@username",txt1.text);
    command.Parameters.AddWithValue("@password",txt2.text);
    command.Parameters.AddWithValue("@val",ddl.SelectedItem.Value);
    command.ExecuteNonQuery();
    
    con.Close(); 
