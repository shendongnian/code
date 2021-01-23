    using (MySqlConnection connection = new MySqlConnection("server=YOUR_SERVER;database=YOUR_DATABASE;uid=YOUR_USERNAME;password=YOUR_PASSWORD;"))
    {
         connection.Open();
         MySqlCommand userinfoCommand = new MySqlCommand("SELECT name, FROM table",connection);
    
         using (MySqlDataReader reader = userinfoCommand.ExecuteReader())
         {
              while (reader.Read())
              {
                   String name= reader.GetString("name");
              }
    
              connection.Close();
         }
    }
