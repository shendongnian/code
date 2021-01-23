    System.Data.DataTable KB = new System.Data.DataTable();
    string[] tags = "some,foo,bar".Split(',');
    System.Collections.Generic.List<string> suggestions = new System.Collections.Generic.List<string>();
    
    for (int i = 0; i < tags.Length; i++)
    {
    	for (int j = 0; j < KB.Rows.Count; j++)
    	{
    		string row = KB.Rows[j]["Title"].ToString();
    		if ((row.Contains(tags[i]))
    		{
    			suggestions.Add(row);
    		}
    	}
    }
