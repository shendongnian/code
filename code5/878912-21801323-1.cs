    namespace Example.Converters
    {
      public class PrefixConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            else return ((string)value).Substring(0, 3);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
      }
      public class PostixConverter : IValueConverter
      {
          public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
          {
            if (value == null) return null;
            else return ((string)value).Substring(4);
          }
          public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
          {
            throw new NotImplementedException();
          }
      }
    }
