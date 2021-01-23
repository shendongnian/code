    public class DoubleToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Values bound to sliders are going to be doubles.
            return Color.FromScRgb((float)(double)values[0], (float)(double)values[1], (float)(double)values[2], (float)(double)values[3]);
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Color C = (Color)value;
            return new object[] { (double)C.ScA, (double)C.ScR, (double)C.ScG, (double)C.ScB };
        }
    }
