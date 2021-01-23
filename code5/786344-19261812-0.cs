    public static T PopulateWithSqlReader<T>(this T objWithProperties, IDataReader dataReader, FieldDefinition[] fieldDefs, Dictionary<string, int> indexCache)
    {
    	try
    	{
    		foreach (var fieldDef in fieldDefs)
    		{
                int index;
                if (indexCache != null)
                {
                    if (!indexCache.TryGetValue(fieldDef.Name, out index))
                    {
                        index = dataReader.GetColumnIndex(fieldDef.FieldName);
                        if (index == NotFound)
                        {
                            index = TryGuessColumnIndex(fieldDef.FieldName, dataReader);
                        }
    
                        indexCache.Add(fieldDef.Name, index);
                    }
                }
                else
                {
                    index = dataReader.GetColumnIndex(fieldDef.FieldName);
                    if (index == NotFound)
                    {
                        index = TryGuessColumnIndex(fieldDef.FieldName, dataReader);
                    }
                }
                   
    			if (index == NotFound) continue;
    			var value = dataReader.GetValue(index);
    			fieldDef.SetValue(objWithProperties, value);
    		}
    	}
    	catch (Exception ex)
    	{
    		Log.Error(ex);
    	} 
    	return objWithProperties;
    }
