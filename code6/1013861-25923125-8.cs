    public class TimeStringToIsLateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            // Do the conversion from your Time (ie value) to your "should the text be red" bool
            return ((string)value) == "456";
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            // Not needed!
            return null;
        }
    }
