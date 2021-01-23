    public class NumberToColor : IValueConverter
    {
        private SolidColorBrush[] tableOfColors = new SolidColorBrush[] 
        {
            new SolidColorBrush(Colors.Yellow), // Number = 1
            new SolidColorBrush(Colors.Red)     // Number = 2
        };
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {            
            if (value == null) return new SolidColorBrush(Colors.Black);
            else return tableOfColors[int.Parse((string)value) - 1];
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Array.FindIndex(tableOfColors, brush => brush == (SolidColorBrush)value);
        }
    }
