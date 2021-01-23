    public class ORConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, 
               object parameter, System.Globalization.CultureInfo culture)
        {
             var list = parameter as IList;
             if (list == null)
                 return false;
             foreach (var o in list)
             {
                 if (Equals(o, value))
                    return true;
             }
             return false;
        }
        public object ConvertBack(object value, Type targetType, 
               object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }
