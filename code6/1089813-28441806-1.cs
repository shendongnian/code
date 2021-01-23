    public class ColorConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, 
          object parameter, CultureInfo culture)
      {   
        return (int)value > 0 ? Visibility.Visible : Visibility.Collapsed
      }
    
      public object ConvertBack(object value, Type targetType, 
          object parameter, CultureInfo culture)
      {
        throw new NotImplmentedException();
      }
    }
