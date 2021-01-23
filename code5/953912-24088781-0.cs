    public class BinaryOrHexConverter : IValueConverter    
    {        
        public object Convert(object value, Type targetType, object parameter,
                      System.Globalization.CultureInfo culture)        
        {
            int result;
            return int.TryParse(inputString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result) ? result.ToString() : value.ToString() // Assuming default is binary
        }
 
    public object ConvertBack(object value, Type targetType, object parameter,
                    System.Globalization.CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }            
}
