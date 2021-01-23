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
            if (value is string)
            {
                decimal d;
                var formatinfo = new NumberFormatInfo();
                formatinfo.NumberDecimalSeparator = ".";
                if (decimal.TryParse((string)value, NumberStyles.Float, formatinfo, out d))
                {
                    return d;
                }
                formatinfo.NumberDecimalSeparator = ",";
                if (decimal.TryParse((string)value, NumberStyles.Float, formatinfo, out d))
                {
                    return d;
                }
            }
            return 0.0;
        }
    }
