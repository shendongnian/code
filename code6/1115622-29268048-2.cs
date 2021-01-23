    public class RemoveNewLineConverter : IValueConverter
    {
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        object val = value is string ? value : string.Empty;
        return ((string)val).Replace(Environment.NewLine, string.Empty);
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        throw new NotImplementedException("Method not implemented");
      }
    }
