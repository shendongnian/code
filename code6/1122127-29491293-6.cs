    public static class RegexExtension
    {
    	public static IEnumerable<string> CapturingGroups(this GroupCollection c) {
    		var result = new List<string>();
    		if (c.Count == 1) return result;
    		
    		//We only one index 1 and over since 0 is actually the entire string		
    		for(var i = 1; i < c.Count; i++) {
    			yield return c[i].Value;
    		}
    	}
    }
