    public class DecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
                              object parameter, string language)
        {
            return value.ToString();
        }
    
        public object ConvertBack(object value, Type targetType, 
                                  object parameter, string language)
        {
            decimal d;
            if (value is string)
            {
                if (decimal.TryParse((string)value, out d))
                {
                    return d;
                }
            }
            return 0.0;
        }
    }
