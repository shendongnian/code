    public class MouseOverToBackgroundConverter : IMultiValueConverter
    {
      public Brush NormalBackground { get; set; }
      public Brush SelfMouseOverBackground { get; set; }
      public Brush MouseOverBackground { get; set; }
    
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        if (values[0] is bool && values[1] is bool) {
          var selfIsMouseOver = (bool)values[0];
          var otherIsMouseOver = (bool)values[1];
          if (selfIsMouseOver) {
            return this.SelfMouseOverBackground;
          }
          return otherIsMouseOver ? this.MouseOverBackground : this.NormalBackground;
        }
        return this.NormalBackground;
      }
    
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
        return targetTypes.Select(t => DependencyProperty.UnsetValue).ToArray();
      }
    }
