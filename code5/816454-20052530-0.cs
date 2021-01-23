    using(var con2 = GetConnection())
    using(var command = new SqlCommand(query, con2))
    {
        command.Parameters.AddWithValue("@s", s);
        con2.Open();
    
        command.ExecuteNonQuery();
    }
