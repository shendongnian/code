    public class AccessLevelToVisibilityConverter : IMultiValueConverter {
        public object Convert(
                object[] values, Type targetType, object parameter, CultureInfo culture)
           {
                int count = values.All(v => (v is int);
                string id = "D" + values.All(v => (v is TypeYouAreExpectingHere).ToString().PadLeft(count);
                return id;
            }
        
            public object[] ConvertBack(
                object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException();
            }
        }
