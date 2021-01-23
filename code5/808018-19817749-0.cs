    using (var writer = new System.IO.StreamWriter(fileName))
    using (var conn = new SqlConnection(connectionString))
    {
        using (var cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT * FROM Organizations WHERE org_type_cd = 1 ORDER BY org_ID";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = (int)reader["org_ID"];
                    int org_type_cd = (int)reader["org_type_cd"];
                    writer.WriteLine(...);
                }
            }
        }
    }
