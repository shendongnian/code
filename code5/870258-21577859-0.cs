    using (var con = new SqlConnection(connectionstring))
    {
        con.Open();
        using (var cmd = new SqlCommand("<YOUR QUERY TEXT>", con))
        {
            cmd.Parameters.AddWithValue("@val", yourValue);
    
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ...
                }
            }
        }
    }
