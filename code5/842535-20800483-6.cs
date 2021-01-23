    public static DataTable From_Obj_Lst(object list)
    {
    	DataTable dt = null;
    	Type listType = list.GetType();
    	if (listType.IsGenericType)
    	{
    		Type elementType = listType.GetGenericArguments()[0];
    		dt = new DataTable(elementType.Name + "List");
    
    		AddColumns(ref dt, elementType, "");
    
    		IList il = list as IList;
    		foreach (object record in il)
    		{
    			int i = 0;
    			object[] fieldValues = new object[dt.Columns.Count];
    			foreach (DataColumn c in dt.Columns)
    			{
    				fieldValues[i] = GetValueByColumnName(c.ColumnName, record);
    				i++;
    			}
    			dt.Rows.Add(fieldValues);
    		}
    	}
    	return dt;
    }
