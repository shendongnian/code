    public class StringDateTimeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime cOutDateTime = DateTime.Now;
            if (DateTime.TryParse(value.ToString(), out cOutDateTime))
            {
                return cOutDateTime;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }
    }
