	public class SelectionToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == DependencyProperty.UnsetValue) return new SolidColorBrush(Colors.Transparent);
			if ((bool)value) return new SolidColorBrush(Colors.LightGreen);
			return new SolidColorBrush(Colors.Transparent);
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
