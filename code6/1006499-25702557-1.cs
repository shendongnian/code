     using(MySqlConnection cnn = new MySqlConnection(GetConnectionStringFromConfig()))
     {
         using(MySqlCommand cmd = new MySqlCommand(commandText, cnn))
         {
             cnn.Open();
             .......
         }
     }
