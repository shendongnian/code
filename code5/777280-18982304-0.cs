    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            var parameterString = parameter as string;
            if (value != null && parameterString != null)
            {
                return String.Format(CultureInfo.CurrentCulture, "{0:"+ parameterString + "}", value);
            }
            else
            {           
                return string.Empty;
            }
        }
    
    
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture)
        {
            if (targetType == typeof (double))
            {
                return System.Convert.ToDouble(value, CultureInfo.CurrentCulture);
            }
            else if (targetType == typeof(int))
            {
                return System.Convert.ToInt32(value, CultureInfo.CurrentCulture);
            }
            // Any other supported types
            else
            {
                throw new NotImplementedException();
            }
        }
    }
