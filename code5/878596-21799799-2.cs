    namespace Example.Converters
    {
      public class StringToUriSource : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            else return new Uri((string)value, UriKind.Absolute);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? value.ToString() : String.Empty;
        }
      }
    }
