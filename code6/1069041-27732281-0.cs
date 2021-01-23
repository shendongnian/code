    public class EnumConverter : IValueConverter
    {
      public object Converter(object value, ...)
      {
        return Enum.GetValues(value.GetType());
      }
    }
