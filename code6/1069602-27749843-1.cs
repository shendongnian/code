	public class EnumToValuesConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            var enumType = (Type)value;
            return enumType.GetEnumValues();
        }
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
            throw new NotImplementedException();
		}
    }
