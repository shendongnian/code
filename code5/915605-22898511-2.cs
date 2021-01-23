    using(MySqlConnection connc = new MySqlConnection(connstr))
    using(MySqlCommand command = new MySqlCommand("SELECT First_name, Last_name FROM Students", connc))
    {
       using(MySqlDataReader reader = command.ExecuteReader())
       {
          while (reader.Read())
          {
               // reader[0] gets you first column which is First_name
               // reader[1] gets you second column which is Last_name
               // Do your label assingments..
          }
       }
    }
