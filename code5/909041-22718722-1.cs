    private List<Item> Parse(string s)
    {
    	var result = new List<Item>();
    	var numberLines = s.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    
    	foreach (var numberLine in numberLines)
    	{
    		var numbers = numberLine.Split(new[] {'.'}).Reverse();
    
    		Item itemInstance = null;
    		foreach (var number in numbers)
    		{
    			itemInstance = new Item(Convert.ToInt32(number), itemInstance);
    		}
    
    		if (result.Count > 0)
    		{
    			result.Last().NextItem = itemInstance;
    		}
    
    		result.Add(itemInstance);
    	}
    
    	return result;
    }
