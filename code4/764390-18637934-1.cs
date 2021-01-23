    public static IEnumerable<string> GetSelectedTypes(Dictionary<string, List<string>> validTypes, IEnumerable<string> userSelection )
    {
    	foreach (var kvp in validTypes)
        	// if the key is in userSelection, only return the key, but no items
    		if (userSelection.Contains(kvp.Key))
    			yield return kvp.Key;
    		// if not, only return valid items
    		else 
    			foreach (var item in kvp.Value)
    				if (userSelection.Contains(item))
    					yield return item;
    }
