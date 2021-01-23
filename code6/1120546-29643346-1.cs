    public class BooleanToVisibleConverter : IValueConverter
    {
       public object Convert(object value, Type targetType, object parameter, string language)
       {
          if (value is Boolean)
             return (Boolean)value ? Visibility.Visible : Visibility.Collapsed;
        
          return Visibility.Collapsed;
       }
        
       public object ConvertBack(object value, Type targetType, object parameter, string language)
       {
          throw new NotImplementedException();
       }
    }
