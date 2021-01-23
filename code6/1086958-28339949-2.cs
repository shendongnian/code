          public class DateToDateFormatConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			DateTime date = (DateTime) value;
			return DateTime.Now.Date == date.Date ? date.ToString("dd.MM.yyyy HH:MM:SS") : date.ToString("dd.MMMM.yyyy");
		}
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
