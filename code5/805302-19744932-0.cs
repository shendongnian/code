    public static class SkipEx
    {
    	public static IEnumerable<T> LongSkip<T>(this IEnumerable<T> src, 
                                                 long numToSkip)
    	{
    		long counter = 0L;
    		foreach(var item in src)
    		{
    			if(counter++ < numToSkip)continue;
    			yield return item;
    		}
    	}
    }
