    for (int i = 0; i < reader.FieldCount; i++)
    {
        string colName = (renamer != null ? renamer(reader.GetName(i)) 
                                          : reader.GetName(i))
        AppendValue(sb, colName, (i == reader.FieldCount - 1));
    }
