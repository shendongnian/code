    public class MarginConverter : IValueConverter
	{
		const int FIXED_MARGIN = 30;
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (int)value * FIXED_MARGIN;
		}
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	    {
		    return (int)value / FIXED_MARGIN;
	    }  
    }
    
