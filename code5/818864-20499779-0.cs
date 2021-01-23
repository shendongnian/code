    public class DoubleToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return new GridLength((double)value, GridUnitType.Pixel);
            }
            catch (InvalidCastException ex)
            {
                return new GridLength(0, GridUnitType.Auto);
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is GridLength ? ((GridLength)value).Value : 0;
        }
