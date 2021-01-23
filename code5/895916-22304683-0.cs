    using (var command = connection.CreateCommand())
    {
        command.CommandText = query;
        command.Connection = connection;
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var idValue = reader.GetObject(0).ToString(); // would be better to use actual field type, which is unknown at the time I'm writing this
                var posterValue = reader.GetString(1);
                // perform concatenation here using the two variables declared above
                links += String.Format("{0}%{1}%", idValue, posterValue);
            }
        }
    }
