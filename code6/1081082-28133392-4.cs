    class Int32ToValueNameConverter : IValueConverter
    {
        private static readonly Dictionary<int, string> _intToName = new Dictionary<int, string>()
        {
            { 0, "Apple" },
            { 1, "Orange" },
            { 2, "Banana" },
            { 3, "Kiwi" },
        };
        private static readonly Dictionary<string, int> _nameToInt = _intToName.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int && targetType == typeof(string))
            {
                string result;
                if (_intToName.TryGetValue((int)value, out result))
                {
                    return result;
                }
            }
            return Binding.DoNothing;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            if (text != null && targetType == typeof(int))
            {
                int result;
                if (_nameToInt.TryGetValue(text, out result))
                {
                    return result;
                }
            }
            return Binding.DoNothing;
        }
    }
