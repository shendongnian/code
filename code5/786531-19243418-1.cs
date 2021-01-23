    public class IsPairConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // You might want to add additional checks for type safety
            var calculatedValue = (string)value; 
            
            var color = calculatedValue == "YES" ? Colors.Blue : Colors.Gray;
            return new SolidColorBrush { Color = color };
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
