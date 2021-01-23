    var list = new List<string>{"1", "2", "'", "@", "r", "r2", "r1"};
	
    //Process the list into segments/classes for ordering
    var ordered = list
        .Select(d => new { OrderBy = GetOrderByClass(d), Value = d })
        .OrderBy(d => d.OrderBy)
        .ThenBy(d => d.Value)
        .Select(d => d.Value)
        .ToList();
    //Get's a segment/class against an input type
    public int GetOrderByClass(string value)
    {	
    	//Numbers
    	if(Regex.IsMatch(value, "\\d+"))
    		return 0; 
    
    	//Alpha
    	if(Regex.IsMatch(value, "[a-zA-Z0-9]"))
    		return 1;
    		
    	//Everything else
    	return 2;
    }
