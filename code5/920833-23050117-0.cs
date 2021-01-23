    using (var reader = cmd.ExecuteReader())
    {
        // Loop through the records
        while (reader.Read())
        {
            // Get value in columns 1 and 2, assuming they're a string and int
            var someValue = reader.GetString(0);
            var someId = reader.GetInt32(1);
            // Or get by the column name:
            var someValue = reader["some_column"].ToString();
            var someId = Convert.ToInt32(reader["another_column"]);
        }
    }
