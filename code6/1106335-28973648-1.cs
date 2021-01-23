	reader = command.ExecuteReader();
	try
	{
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dbResult.Columns.Add(reader.GetName(i));
                dbResult.Types.Add(reader.GetDataTypeName(i));
            }
            while (reader.Read())
            {
                object[] value = new object[reader.FieldCount];
                reader.GetValues(value);
                List<object> values = new List<object>(value);                    
                Rows.Add(values);
            }                            
	}
	finally
	{
		reader.Close();
	}
