    while (reader.Read())
    {
         for(int i = 0; i < reader.FieldCount; i++)
         {
            arrList.Add((string)reader[i]);
         }
    }
