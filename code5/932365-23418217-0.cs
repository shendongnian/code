    public static class Extensions
    {
    	public static IDictionary<DateTime, T> GetLatest<T>(this IDictionary<DateTime, T> dict, DateTime since)
    	{
    		var returnList = new Dictionary<DateTime, T>();
    		returnList = dict.Where(x => x.Key > since).ToDictionary(x => x.Key, x => x.Value);
    		return returnList;
    	}
    }
