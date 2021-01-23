    public class SumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
                              System.Globalization.CultureInfo culture)
        {
            double sum = 0.0;
            Type valueType = value.GetType();
 
            if(valueType.Name == typeof(List<>).Name)
            {
                foreach (var item in (IList)value)
                {
                    Type itemType = item.GetType();                     
                    PropertyInfo itemPropertyInfo = itemType.GetProperty((string)parameter);
                    double itemValue = (double)itemPropertyInfo.GetValue(item, null); 
                    sum += itemValue;
                }
                return sum;
            }
            return 0.0;
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
                                  System.Globalization.CultureInfo culture)
        { throw new NotImplementedException();  }
    }
