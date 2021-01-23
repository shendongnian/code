	public class MyConverter : DependencyObject, IValueConverter
	{
		public static readonly DependencyProperty InvertProperty = DependencyProperty.Register(
			"Invert", typeof (bool), typeof (MyConverter), new PropertyMetadata(default(bool)));
		public bool Invert
		{
			get { return (bool) GetValue(InvertProperty); }
			set { SetValue(InvertProperty, value); }
		}
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var val = (bool?) value;
			switch (val)
			{
				case true:
					return Invert;
					break;
				case false:
					return !Invert;
					break;
				case null:
					return false; // None of the checkboxes shall be active
					break;
			}
			// Fallback
			return false;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var val = (bool)value;
			switch (val)
			{
				case true:
					return Invert;
					break;
				case false:
					return null;
					break;
			}
			// Fallback
			return false;
		}
	}
