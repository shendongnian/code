    public class AddValueConverter : IMultiValueConverter
    {
    
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int sum = 0;
            int result;
    
            foreach(object value in values)
            {
                if (Int32.TryParse(System.Convert.ToString(value), out result))
                {
                    sum += result;
                }
            }
    
            return System.Convert.ToString(sum);
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
