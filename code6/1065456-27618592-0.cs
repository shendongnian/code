    private List<DataRow> GetDuplicateKeys(DataTable table, List<string> keyFields)
	{
		Dictionary<List<object>, int> keys = new Dictionary<List<object>, int>(); // List of key values + their index in table
		List<List<object>> duplicatedKeys = new List<List<object>>(); // List of duplicated keys values 
		
		List<DataRow> duplicatedRows = new List<DataRow>(); // Rows that are duplicated
		foreach (DataRow row in table.Rows)
		{
			// Find keys fields values for the row
			List<object> rowKeys = new List<object>();
			keyFields.ForEach(keyField => rowKeys.Add(row[keyField]));
			// Check if those keys are already defined
			bool alreadyDefined = false;
			foreach (List<object> keyValue in keys.Keys)
			{
				if (rowKeys.Any(keyValue))
				{
					alreadyDefined = true;
					break;
				}
			}
			if (alreadyDefined)
			{
				duplicatedRows.Add(row);
				// If first duplicate for this key, add the first occurence of this key
				if (!duplicatedKeys.Contains(rowKeys))
				{
					duplicatedKeys.Add(rowKeys);
					int i = keys[keys.Keys.First(key => key.SequenceEqual(rowKeys))];
					duplicatedRows.Add(table.Rows[i]);
				}
			}
			else
			{
				keys.Add(rowKeys, table.Rows.IndexOf(row));
			}
		}
		return duplicatedRows;
	}
