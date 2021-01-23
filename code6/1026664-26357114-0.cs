    public class DictionaryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var key = values[1] as YourKeyType;
            var dictionary = values[0] as Dictionary<YourKeyType, YourValueType>;
            return dictionary[key];
        }
    }
