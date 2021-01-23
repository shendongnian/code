    public static class PathExtensions
    {
    	public static string GetLastPathSegment(this string path)
    	{
    		string lastPathSegment = path
    			.Split(new string[] {@"\"}, StringSplitOptions.RemoveEmptyEntries)
    			.LastOrDefault();
    		
    		return lastPathSegment;
    	}
    }
