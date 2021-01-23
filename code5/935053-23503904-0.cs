    using (SqlConnection connection = new SqlConnection("connectionString"))
    {
        using (SqlCommand command = connection.CreateCommand())
        {
            command.CommandText = "select getdate()";
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //do your stuff...
                }
            }
        }
    }
