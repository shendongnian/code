    internal class MyConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        var input = value.ToString();
        // change "input.Length" in the following line to 8 if you just want 8 "*" regardless of length
        return new String('*', input.Length);
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
