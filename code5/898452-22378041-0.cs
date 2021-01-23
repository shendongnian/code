    // System.Linq.Enumerable
    public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
    	if (source == null)
    	{
    		throw Error.ArgumentNull("source");
    	}
    	if (predicate == null)
    	{
    		throw Error.ArgumentNull("predicate");
    	}
    	foreach (TSource current in source)
    	{
    		if (predicate(current))
    		{
    			return current;
    		}
    	}
    	throw Error.NoMatch();
    }
