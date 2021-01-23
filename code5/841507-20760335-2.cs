    public class IsNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
            bool result = false;
            if (value == null)
            {
                result = true;
            }
            if (targetType == typeof(Visibility))
                return result ? Visibility.Collapsed : Visibility.Visible;
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
