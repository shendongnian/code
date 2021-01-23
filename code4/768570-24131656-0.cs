	public static DataTable CreateDataTable<T>(IEnumerable<T> list)
	{
		Type type = typeof(T);
		var properties = type.GetProperties();		
		
		DataTable dataTable = new DataTable();
		foreach (PropertyInfo info in properties)
		{
			dataTable.Columns.Add(new DataColumn(info.Name, info.PropertyType));
		}
		
		foreach (T entity in list)
		{
			object[] values = new object[properties.Length];
			for (int i = 0; i < properties.Length; i++)
			{
				values[i] = properties[i].GetValue(entity);
			}
			
			dataTable.Rows.Add(values);
		}
		
		return dataTable;
	}
