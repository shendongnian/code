    SqlDataReader reader = command.ExecuteReader();
    var listOfValues = new Dictionary<string, object>();
    while (reader.Read())
    {
       for(int i = 0; i <reader.FieldCount;i++)
       {
          listOfValues.Add(reader.GetName(i), reader.GetValue(i));
       }
    }
