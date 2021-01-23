    public class BoolToStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool) value)
            {
                return Statuses.Start;
            }
            return Statuses.Stop;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var theValue = (Statuses)value;
            if (theValue == Statuses.Start)
            {
                return true;
            }
            return false;
        }
    }
