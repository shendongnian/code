    [ValueConversion(typeof(String), typeof(String))]
    public sealed class ParameterFilter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(null == (parameter as String)) return DependencyProperty.UnsetValue;
            if(null == (value as String)) return DependencyProperty.UnsetValue;
            String[] split = value.ToString().Split(',');
            StringBuilder b = new StringBuilder();
            String cur;
            for (Int32 i = 0; i < split.Length; i++)
            {
                if(String.IsNullOrEmpty(cur = split[i])) continue;
                if(!cur.Contains(parameter.ToString()) continue;
                
                if (b.Length != 0) b.Append(',');
                b.Append(cur);
            }
            return b.ToString();
        }
    }
