    using (var conn = new SqlConnection(ConnectionString))
    {
         conn.Open();
         using (SqlCommand cmd = conn.CreateCommand())
         {
              cmd.CommandText = "SELECT * FROM SomeTable";
              using (SqlDataReader reader = cmd.ExecuteReader())
              {
                   while (reader.Read())
                   {
                       // DO SOME WORK
                   }
              }
         }
    }
