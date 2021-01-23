    public class ZeroToBlank: IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if (value is int && (int)value == 0)
    			return string.Empty;
    
    		return value;
    	}
    
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		if (string.IsNullOrEmpty(value))
    			return 0;
    			
    		return value;
    	} 
    }
