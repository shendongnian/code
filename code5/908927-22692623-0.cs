    using (var conn = new SqlConnection(connectionString)) {
        using (var cmd = new SqlCommand("SELECT name, loc FROM t WHERE id=@id", conn)) {
            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                int nameOrdinal = reader.GetOrdinal("name");
                int locationOrdinal = reader.GetOrdinal("loc");
                while (reader.Read()) {
                    Console.WriteLine("Name = {0}, Location = {1}",
                        reader.GetString(nameOrdinal),
                        reader.GetString(locationOrdinal));
                }
            }
        }
    }
