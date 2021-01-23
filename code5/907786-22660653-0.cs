    using (SqlConnection con = new SqlConnection(SqlConnectionString))
    {
        string sql = @"SELECT * FROM movies WHERE title like '%' + @Search + '%'";
    
        using (var command = new SqlCommand(sql, con))
        {
            command.Parameters.AddWithValue("@Search", searchQuery);
            con.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
    
                }
            }
        }
    }
