    public static class ModelExtensions
    {
    	public static TResult SafeGet<TSource, TResult>(this TSource obj, System.Func<TSource, TResult> selector) where TResult : class
    	{
    		try
    		{
    			return selector(obj) ?? default(TResult);
    		}
    		catch(System.NullReferenceException e)
    		{
    			return default(TResult);
    		}
    	}
    }
