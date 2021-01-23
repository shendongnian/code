    public class BoolToVisibilityConverter : IValueConverter
	{
		public bool VisibleIfTrue { get; set; }
		public BoolToVisibilityConverter(){VisibleIfTrue = true;}
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (VisibleIfTrue)
				return ((bool) value) ? Visibility.Visible : Visibility.Collapsed;
			else
				return ((bool) value) ? Visibility.Collapsed : Visibility.Visible;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture){throw new NotSupportedException();}
	}
