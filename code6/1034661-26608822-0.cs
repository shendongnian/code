    public class NullableDecimalConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture) { return value; }
		public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
		{
			string decimalString = value as string;
			decimal parsedDecimal;
			if (decimalString != null && Decimal.TryParse( decimalString,
                                                           out parsedDecimal ))
				return parsedDecimal;
			else
				return null;
		}
	}
