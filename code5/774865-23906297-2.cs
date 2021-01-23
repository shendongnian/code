    public static class EnumsHelper
    {
    	...
    
    	public static string GetDescription(this Enum enumVal)
    	{
    		var attr = GetAttributeOfType<MyDescriptionAttribute>(enumVal);
    		return attr != null ? attr.Text : string.Empty;
    	}
    }
