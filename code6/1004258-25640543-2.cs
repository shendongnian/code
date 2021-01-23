    var dt = new DataTable("Test");
    DataRow workRow;
    
    for (int i = 0; i < types.Count; i++)
    {
    	dt.Columns.Add(types[i]);
    	var dataToInsert = lst.Where (l => l.Type == types[i]).Select (l => l.Data).ToList();
    	foreach (var element in dataToInsert)
    	{
    		workRow = dt.NewRow();
    		workRow[types[i]] = element;
    		dt.Rows.Add(workRow);
    	}
    }
