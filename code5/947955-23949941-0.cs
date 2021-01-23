    public class LocalizationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = value as string;
            if (!string.IsNullOrEmpty(key))
            {
                string dictionaryValue = Resources.ResourceManager.GetString(key);
                return dictionaryValue ?? key;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
