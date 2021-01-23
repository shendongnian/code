    public class CompareTwoValues : IMultiValueConverter
    {
      public CompareTwoValues()
      {
        base..ctor();
      }
      public bool Execute(string value1, string value2)
      {
        return value1 == value2;
      }
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        // convert the values to the target type
      }
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
        // convert the value back to the set of target types
      }
    }
