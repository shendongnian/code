     using(MySqlConnection cnn = new MySqlConnection(....connectionstring..))
     using(MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE yourTableName", cnn))
     {
         cnn.Open();
         cmd.ExecuteNonQuery();
     }
