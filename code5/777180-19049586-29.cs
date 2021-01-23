    public class TimeRangeToVerticalMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TimeRange))
                return null;
            var range = (TimeRange) value;
            return new Thickness(2, range.Start.TotalMinutes - range.Base.TotalMinutes, 2, 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class TimeRangeHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TimeRange))
                return null;
            var range = value as TimeRange;
            return range.End.Subtract(range.Start).TotalMinutes;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
   
