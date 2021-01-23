    public static class RegexExtension
    {
    	public static IEnumerable<string> CapturingGroups(this GroupCollection c) {		
    		var query = c.OfType<Group>().Select(g => g.Value);
    		
    		if (c.Count == 1)
    			query = query.Skip(1);
    		
    		//We only one index 1 and over since 0 is actually the entire string
    		return query;
    	}
    }
