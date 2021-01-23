    while (reader.Read())
    {
      List<string> fields = new List<string>();
      for (int i = 0; i < reader.FieldCount; i++)
      {
        fields.Add(Convert.ToString(reader[i]));
      }
      csvList.Add(string.Join(",", fields.ToArray());
    }
    
    for (int index = 0; index < csvList.Count; index++)
    {
      sb.AppendLine(csvList[index]);
    }
