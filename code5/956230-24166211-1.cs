     public class StatusToBooleanConverter : IValueConverter
    {
        public static StatusToBooleanConverter Instance = new StatusToBooleanConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Status)
            {
                switch ((Status)value)
                {
                    case Status.Completed:
                        return true;
                    case Status.Pending: 
                        return false;
                }
                return null;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
