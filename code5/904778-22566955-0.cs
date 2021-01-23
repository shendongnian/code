    public static class ExtensionMethods{
    	public static bool ContainsAny(this string s, params string[] tokens){
    		return tokens.Any(t => s.Contains(t));
    	}
    	
    	public static bool ContainsAll(this string s, params string[] tokens){
    		return tokens.All(t => s.Contains(t));
    	}
    }
