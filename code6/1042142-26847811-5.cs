    using(SqlConnection con = new SqlConnection(Settings.DatabaseConnectionString))
    using(SqlCommand cmd = new SqlCommand(query, con))
    {
         con.Open();
         // The query will return just one row with eight columns
         using(SqlDataReader reader = cmd.ExecuteReader())
         {
           if(reader.Read())
           {  
             // The column at ordinal 0 is the DayProduction one....
             // Check if column at ordinal 1 (Sunday) contains a DBNull.Value or not...
             int sunday = reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader[1]);
             int monday = reader.IsDBNull(2) ? 0 : Convert.ToInt32(reader[2]);
             int tuesday = reader.IsDBNull(3) ? 0 : Convert.ToInt32(reader[3]);
             int wednesday = reader.IsDBNull(4) ? 0 : Convert.ToInt32(reader[4]);
             int thursday = reader.IsDBNull(5) ? 0 : Convert.ToInt32(reader[5]);
             int friday = reader.IsDBNull(6) ? 0 : Convert.ToInt32(reader[6]);
             int saturday = reader.IsDBNull(7) ? 0 : Convert.ToInt32(reader[7]);
           }
         }
    }
