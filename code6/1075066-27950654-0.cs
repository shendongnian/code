    DataRow row;
    foreach (var record in data)
    {
    	row = table.NewRow();
    	for (int i = 0; i < table.Columns.Count; i++)
    	{
    		values[i] = props[i].GetValue(record) != null ? props[i].GetValue(record) : DBNull.Value;
    	}
        // You do not set the row columns anywhere.
    	table.Rows.Add(row);
        // This would work but I'm not sure what you are trying to do.
    	// table.Rows.Add(values);
    }
    // You add an extra row here: is this intended?
    table.Rows.Add(values);
