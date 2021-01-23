    public static class StringExtensions
    {
    	public static string EqualsCaseInsensitive(this string str, string other)
    	{
    		return string.Equals(str, other, StringComparison .InvariantCultureIgnoreCase);
    	}
    }
