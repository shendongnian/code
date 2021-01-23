    public class RowHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var isVisible = value as bool?;
            if (isVisible.HasValue && isVisible.Value)
                return new GridLength(1, GridUnitType.Star);
            else
                return new GridLength(0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
