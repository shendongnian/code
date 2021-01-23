      public class BooleanToVisibilityConverter : IValueConverter 
      {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {            
             if (value == null || !(value is bool)) return Visibility.Collapsed;
             return (bool)value ? Visibility.Visible : Visibility.Collapsed; 
         }
         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             return value;
         }
     }
