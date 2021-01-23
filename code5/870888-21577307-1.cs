    namespace My.App.Converters
    {
      [ValueConversion(typeof(bool?), typeof(Visibility))]
      public class NullableBooleanToVisibilityConverter : IValueConverter
      {
        public static NullableBooleanToVisibilityConverter Instance = new NullableBooleanToVisibilityConverter();
        
       /* Convert and ConvertBack methods */
      }
    }
