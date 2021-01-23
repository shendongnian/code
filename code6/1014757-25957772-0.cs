    using(SqlConnection con = Dal.GetConnection())
    {
      while(reader.Read())
      {
         // some code
      }
    }
