    public class EnumConverter : IValueConverter
    {
      public object Convert(object value, ...)
      {
        return Enum.GetValues(value.GetType());
      }
    }
