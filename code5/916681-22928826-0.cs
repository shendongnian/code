    public class borderConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, 
        object parameter, CultureInfo culture)
    {
        if (value is bool)
        {
          if (!(bool)value == true)
            return new SolidColorBrush(Colors.Red);
        }
        return new SolidColorBrush(Colors.Green);
    }
 
    public object ConvertBack(object value, Type targetType, 
        object parameter, CultureInfo culture)
    {
        throw NotImplementedException();
    }
    }
