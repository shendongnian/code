	public class Inverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is bool)
				return !((bool)value);
			else // Fallback
				return false;
		}
	}
    
