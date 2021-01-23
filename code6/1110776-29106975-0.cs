    public class LineLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {            
            var textBox = value as TextBlock;
            double textHeight = textBox.ActualHeight;
            var endpoint = new Point(7.0, textHeight);
            return endpoint;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
