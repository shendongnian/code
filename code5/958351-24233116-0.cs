     public class DoubleConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value !=null)
            {
                return value.ToString();
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string data = value as string;
            if (data == null)
            {
                return value;
            }
            if (data.Equals(string.Empty))
            {
                return 0;
            }
            if (!string.IsNullOrEmpty(data))
            {
                decimal result;
                //Hold the value if ending with .
                if (data.EndsWith(".") || data.Equals("-0"))
                {
                    return Binding.DoNothing;
                }
                if (decimal.TryParse(data, out result))
                {
                    return result;
                }
            }
            return Binding.DoNothing;
        }
    }
