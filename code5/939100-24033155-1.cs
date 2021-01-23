    public class SamenessConverter : IMultiValueConverter {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
        return values.All(x => x == values[0]);
      }
      // ...
    }
