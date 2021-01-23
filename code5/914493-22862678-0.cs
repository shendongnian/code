    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Status)value)
            {
                case Status.State1:
                    return new SolidColorBrush(Colors.Red);
                case Status.State2:
                    return new SolidColorBrush(Colors.Green);
                case Status.State3:
                    return new SolidColorBrush(Colors.Blue);
                default:
                    throw new ArgumentException();
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
