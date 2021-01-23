     using(MySqlConnection cnn = new MySqlConnection(GetConnectionString())
     {
         using(MySqlCommand cmd = new MySqlCommand(commandText, cnn))
         {
             cnn.Open();
             .......
         }
     }
