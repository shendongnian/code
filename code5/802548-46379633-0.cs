	// function that creates an object from the given data row
	public static T CreateItemFromRow<T>(DataRow row) where T : new()
	{
		// create a new object
		T item = new T();
		// set the item
		SetItemFromRow(item, row);
		// return 
		return item;
	}
	public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
	{
		// go through each column
		foreach (DataColumn c in row.Table.Columns)
		{
			// find the property for the column
			PropertyInfo p = item.GetType().GetProperty(c.ColumnName);
			// if exists, set the value
			if (p != null && row[c] != DBNull.Value)
			{
				if (p.PropertyType.Name == "Int64")
				{
					p.SetValue(item, long.Parse(row[c].ToString()), null);
				}
				else if (p.PropertyType.Name == "Int32")
				{
					p.SetValue(item, int.Parse(row[c].ToString()), null);
				}
				else if (p.PropertyType.FullName.StartsWith("System.Nullable`1[[System.Int32"))
				{
					p.SetValue(item, (int?)int.Parse(row[c].ToString()), null);
				}
				else if (p.PropertyType.FullName.StartsWith("System.Nullable`1[[System.Int64"))
				{
					p.SetValue(item, (long?)long.Parse(row[c].ToString()), null);
				}
				else
				{
					p.SetValue(item, row[c], null);
				}
			}
		}
	}
