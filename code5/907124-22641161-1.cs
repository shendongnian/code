    var dict = new Dictionary<string, Action<long>>();
    dict.Add("change_bank_details_policy", v => change_bank_details_policy = v);
    // 40 of these, no choice
    
    int i = 1;
    object isRow = currentWorksheet.Cells[i, 1].Value;
    while (isRow != null)
    {
    	string rowTitle = isRow.ToString().Trim();
    	if (dict.ContainsKey(rowTitle))
    	{
    		// Or parse it or whatever you have to do to handle the cell value type
    		long rowValue = currentWorksheet.Cells[i,2].Value; 
    		dict[rowtitle](rowValue);
    	}
    
    	isRow = currentWorksheet.Cells[++i, 1].Value;
    }
