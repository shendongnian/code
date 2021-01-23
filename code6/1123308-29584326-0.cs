    List<List<string>> table = new List<List<string>>();
    
    
    var match = Regex.Match(raw, @"(?:(?:\|\|([^|]*))*\n)?");
    if (match.Success)
    {
    	var headersWithExtra = match.Groups[1].Captures.Cast<Capture>().Select(c=>c.Value);
    	List<String> headerRow = headersWithExtra.Take(headersWithExtra.Count()-1).ToList();
    	if (headerRow.Count > 0)
    	{
    		table.Add(headerRow);
    	}
    }
    
    match = Regex.Match(raw + "\r\n", @"[^\n]*\n" + @"(?:\|([^|]*))*");
    var cellsWithExtra = match.Groups[1].Captures.Cast<Capture>().Select(c=>c.Value);
    
    List<string> row = new List<string>();
    foreach (string cell in cellsWithExtra)
    {
    	if (cell.Trim(' ', '\t') == "\r\n")
    	{
    		if (!table.Contains(row) && row.Count > 0)
    		{
    			table.Add(row);
    		}
    		row = new List<string>();
    	}
    	else
    	{
    		
    		row.Add(cell);
    	}
    }
