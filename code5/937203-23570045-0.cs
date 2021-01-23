    var dict = new Dictionary<string, IList<int>>();
    
    var uniques = new Dictionary<string, IList<int>>();
    
    foreach (var list in dict)
    {
    	if(!uniques.Any(val => val.Value.SequenceEqual(list.Value)))
    		uniques.Add(list.Key, list.Value);
    }
