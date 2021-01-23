    public class VisibilityToStarHeightConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        if ((Visibility)value == Visibility.Collapsed) {
          return new GridLength(0, GridUnitType.Star);
        } else {
          if (parameter == null) {
            throw new ArgumentNullException("parameter");
          }
          return new GridLength(double.Parse(parameter.ToString(), culture), GridUnitType.Star);
        }
      }
    …
