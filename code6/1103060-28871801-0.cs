    public static class NullExtensions
    {
    	public delegate bool TryGetValue<T>(string input, out T value);
    
    	public static T DefaultIfNull<T>(this string value, TryGetValue<T> evaluator, T defaultValue) where T : struct
    	{
    		T result;
    
    		if (evaluator(value, out result))
    			return result;
    
    		return defaultValue;
    	}
    
    	public static T DefaultIfNull<T>(this string value, TryGetValue<T> evaluator) where T : struct
    	{
    		return value.DefaultIfNull(evaluator, default(T));
    	}
    }
    
