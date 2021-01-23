    public class BooleanToBrushConverter
    		: IValueConverter
    	{
    		public Brush TrueBrush { get; set; }
    		public Brush FalseBrush { get; set; }
    
    		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    		{
    			if (value is bool)
    			{
    				return (bool) value
    					? TrueBrush
    					: FalseBrush;
    			}
    
    			return value;
    		}
    
    		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    		{
    			throw new NotImplementedException();
    		}
    	}
