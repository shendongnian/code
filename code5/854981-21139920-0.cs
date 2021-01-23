    public class ResourceStringConventer : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, string language)
    	{     
    		ResourceLoader resourceLoader = new ResourceLoader();
    		string text = resourceLoader.GetString((string)parameter);
    		return text;
    	}
    	public object ConvertBack(object value, Type targetType, object parameter, string language)
    	{
    		throw new NotImplementedException();
    	}
    }
    
