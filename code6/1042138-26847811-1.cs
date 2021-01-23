    using(SqlConnection con = new SqlConnection(Settings.DatabaseConnectionString))
    using(SqlCommand cmd = new SqlCommand(query, con))
    {
         con.Open();
         using(SqlDataReader reader = cmd.ExecuteReader())
         {
             int sunday = reader.IsDBNull(1) ? 0 : Convert.ToInt32(reader(1));
             int monday = reader.IsDBNull(2) ? 0 : Convert.ToInt32(reader(2));
             int tuesday = reader.IsDBNull(3) ? 0 : Convert.ToInt32(reader(3));
             int wednesday = reader.IsDBNull(4) ? 0 : Convert.ToInt32(reader(4));
             int thursday = reader.IsDBNull(5) ? 0 : Convert.ToInt32(reader(5));
             int friday = reader.IsDBNull(6) ? 0 : Convert.ToInt32(reader(6));
             int saturday = reader.IsDBNull(7) ? 0 : Convert.ToInt32(reader(7));
         }
    }
