    using (SqlConnection c = new SqlConnection(cString))
    {
        using (SqlCommand cmd = new SqlCommand(sql, c))
        {
            // inside of here you can use ExecuteReader
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                // use the reader
            }
        }
    }
