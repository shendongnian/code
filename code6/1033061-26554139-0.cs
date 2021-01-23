    public static class StringExtensions
    {
    	public static string GetValueOrNotAvailable(this string value)
    	{
    		return value ?? "N/A";
    	}
    }
