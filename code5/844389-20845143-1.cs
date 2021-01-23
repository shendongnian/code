    public class IndexBooleanConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value == null || parameter == null)
            return false;
         else
            return (int)value == System.Convert.ToInt32(parameter);
      }
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         if (value == null || parameter == null)
             return null;
         else if ((bool)value)
             return System.Convert.ToInt32(parameter);
         else
             return DependencyProperty.UnsetValue;
      }
    }   
