     using(SqlConnection cnn = new SqlConnection(....connectionstring..))
     using(SqlCommand cmd = new SqlCommand("TRUNCATE TABLE yourTableName", cnn))
     {
         cnn.Open();
         cmd.ExecuteNonQuery();
     }
