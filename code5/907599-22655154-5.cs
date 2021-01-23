    using(SqlConnection connection = new SqlConnection(connectionString))
    using(SqlCommand cmd1 = connection.CreateCommand())
    {
        ...
        ...
        connection.Open();
        using(SqlDataReader reader = cmd1.ExecuteReader())
        {
            while (reader.Read())
            {
                Response.Write(reader[0].ToString()); //This writes first column values for your all rows.
            }
        }
    }
