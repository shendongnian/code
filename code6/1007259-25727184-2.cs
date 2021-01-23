    public class StringToUpper: IValueConverter
    {
        public object Convert(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            var valueString = value.ToString();
            if (!string.IsNullOrEmpty(valueString))
            {
                return valueString.ToUpper();
            }
            return string.Empty;
        }
     
        public object ConvertBack(object value, Type targetType, 
            object parameter, CultureInfo culture)
        {
            // do nothing.
        }
    }
