    class BoxTypeConverter : IValueConverter
    {
        private static readonly List<string> idNames = new List<string>()
        {
            "Flat-rate (small)",
            "Flat-rate (medium)",
            "Flat-rate (large)",
            "Regional A",
            "Regional B",
            "Regional C"
        };
    
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = (int)value - 1;
    
            return index >= 0 && index < idNames.Count ? idNames[index] : value;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var idName = (string)value;
            var index = idNames.IndexOf(idName);
    
            return index >= 0 ? index + 1 : int.Parse(idName, culture);
        }
    }
