    while (reader.Read())
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            var value = reader[i];
            arrList.Add(Convert.ToString(value))
        }
    }
