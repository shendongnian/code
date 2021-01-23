    public class RemoveNewLineConverter : IValueConverter
    {
      private object original;
      public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        this.original = value is string ? value : string.Empty;
        return ((string)this.original).Replace(Environment.NewLine, string.Empty);
      }
      public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
      {
        return this.original;
      }
    }
