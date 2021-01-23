    public class IntegerToColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
              System.Globalization.CultureInfo culture)
        {
            switch ((int)value)
            {
                case 1: return Color.Red; break;
                case 2: return Color.Yellow; break;
                Default: return Color.White; break;
            }
        }
    }
 
