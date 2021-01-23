    class ChangeSignConverter : IValueConverter
    {
      object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return Convert.ToDouble(value) * -1;
      }
    
      object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return Convert.ToDouble(value) * -1;
      }
    }
