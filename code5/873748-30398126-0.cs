     public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return string.Empty;
            }
            return string.Format((parameter as string) ?? "{0}", value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (string.IsNullOrEmpty(System.Convert.ToString(value)))
            {
                if (targetType.IsNullable())
                {
                    return null;
                }
                return 0;
            }
            if (targetType == typeof (double))
            {
                return System.Convert.ToDouble(value);
            }
            if (targetType == typeof(decimal))
            {
                return System.Convert.ToDecimal(value);
            }
            if (targetType == typeof(int))
            {
                return System.Convert.ToInt16(value);
            }
            if (targetType == typeof(Int32))
            {
                return System.Convert.ToInt32(value);
            }
            return value;
        }
    }
