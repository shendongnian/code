    public class ElementToTypeConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, 
                        object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? Type.Missing : value.GetType();
        }
        object IValueConverter.ConvertBack(object value, Type targetType, 
                        object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
