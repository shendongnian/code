    public static class StringExt
    {
    	public static bool IsNumeric(string text)
    	{
    		double test;
    		return double.TryParse(text, out test);
    	}
    }
