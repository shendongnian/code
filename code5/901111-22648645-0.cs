    using (MySqlConnection connection = new MySqlConnection("YourConnectionString"))
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
