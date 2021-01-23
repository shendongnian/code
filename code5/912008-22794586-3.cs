    public static class StringExt
    {
    	public static bool IsNumeric(this string text)
    	{
    		return double.TryParse(text, out double test);
    	}
    }
