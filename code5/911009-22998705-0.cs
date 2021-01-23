    public class MyBooleanConverter : DefaultTypeConverter
    {
    	public override string ConvertToString( TypeConverterOptions options, object value )
    	{
    		if( value == null )
    		{
    			return string.Empty;
    		}
    		
    		var boolValue = (bool)value;
    		
    		return boolValue ? "yes" : "no";
    	}
    }
