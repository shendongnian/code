     using(SqlConnection cnn = new SqlConnection(....connectionstring..))
     using(SqlCommand cmd = new SqlCommand("DELETE FROM yourTableName WHERE ... your condition...", cnn))
     {
         cnn.Open();
         cmd.ExecuteNonQuery();
     }
