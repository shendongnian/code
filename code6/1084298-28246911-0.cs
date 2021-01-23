       string connString = "datasource=x5x.1x1.13x.xxx;Database=business;username=sumon;password=root";
       MySqlConnection connect = new MySqlConnection(connString);
       MySqlCommand myCommand = connect.CreateCommand();
       myCommand.Parameters.Add(new SqlParameter("input", 10));
       //string input = textBox1.Text;
    
       myCommand.CommandText = "SELECT * FROM life WHERE id = @input";
       connect.Open();
           MySqlDataReader reader = myCommand.ExecuteReader();
    
           if (reader.Read())
               textBox1.Text = reader["Email_id"].ToString();
    
           connect.Close();
