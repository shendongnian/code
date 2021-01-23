     public class DoubleStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value.ToString();
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                   return double.Parse(value.ToString());
                }
                catch
                {
                    return 12.0;
                }
            }
        }
