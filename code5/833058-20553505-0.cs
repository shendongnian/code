	public static DataTable ToDataTable<T>(this IEnumerable<Dictionary<string,T>> source)
	{
		DataTable table = new DataTable(); 
		foreach(var dict in source)
		{
			var dr = table.NewRow();
			foreach(var entry in dict)
			{
				if (!table.Columns.Contains(entry.Key))
					table.Columns.Add(entry.Key, typeof(T));
				dr[entry.Key] = entry.Value;
			}
			table.Rows.Add(dr);
		}
	
		return table;		
	}
