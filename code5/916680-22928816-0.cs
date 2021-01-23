    public sealed class BoolToColorConverter : IValueConverter
    {
    		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		bool bValue = (bool)value;
    		if (bValue)
    			return Color.Green;
    		else
    			return Color.Red;
    	}
    	
    	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    	{
    		Color color = (Color)value;
    
    		if (color == Color.Green)
    			return true;
    		else
    			return false;
    
    	}
    }
