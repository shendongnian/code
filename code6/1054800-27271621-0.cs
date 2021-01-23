    public sealed class LengthConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // values array will contain both MinimumRebarsVerticalDistance and 
            // CurrentDisplayUnit values
            // ...
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            // ...
        }
    }
