    public class ItemsToAverageConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter,
                                                           CultureInfo culture){
        var propName = Convert.ToString(parameter);
        var items = (IEnumerable<Item>) value;
        var prop = typeof(Item).GetProperty(propName);
        if(prop == null) return Binding.DoNothing;
        return items.Average(i => (double) prop.GetValue(i));
      }
      public object Convert(object value, Type targetType, object parameter,
                                                           CultureInfo culture){
        throw new NotImplementedException();
      }
    }
