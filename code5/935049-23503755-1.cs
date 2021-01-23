    using (cmd = new SqlCommand("SELECT * FROM [table-one]", conn))
    {
         using (reader = cmd.ExecuteReader())
         {
             if (reader.HasRows)
             {
                 // Get a temporary copy of the data in a data table
                 dt.Load(reader);
             }
         }
    }
    // Do database things on table-one
