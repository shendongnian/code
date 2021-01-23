    public class UtcToZonedDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DateTime.MinValue;
            }
    
            if (value is DateTime)
            {
                return ((DateTime)value).ToLocalTime();
            }
    
            DateTime parsedResult;
            if (DateTime.TryParse(value?.ToString(), out parsedResult))
            {
                return parsedResult.ToLocalTime();
            }
    
            return DateTime.MinValue;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
