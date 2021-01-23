    public class TimeSpanToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        { return (value == null) ? 0 : ((TimeSpan)value).TotalSeconds; }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        { throw new NotImplementedException(); }
    }
    public class DurationToDouble : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        { return (value == null) ? 0 : ((Duration)value).TimeSpan.TotalSeconds; }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        { throw new NotImplementedException(); }
    }
