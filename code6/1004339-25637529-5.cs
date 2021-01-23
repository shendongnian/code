    using(MySqlConnection con = new MySqlConnection(str))
    using(MySqlCommand cmd = con.CreateCommand())
    {
       ...
       ...
       using(MySqlDataReader reader = cmd.ExecuteReader())
       {
          while (reader.Read())
          {
             for(int i = 0; i < reader.FieldCount; i++)
             {
                arrList.Add((string)reader[i]);
             }
          } 
       }
    }
