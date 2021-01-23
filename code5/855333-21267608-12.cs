    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
    	var s = string.Empty;
    
    	try
    	{
    		s = value.ToString().Trim().Replace("\\n", Environment.NewLine);
    	}
    	catch
    	{
    		// value is most likely null;
    	}
    
    	return s;
    }
    
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
    	throw new NotImplementedException();
    }
