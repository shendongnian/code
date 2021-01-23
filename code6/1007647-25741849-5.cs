    public class RadioButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || parameter == null)
            {
                return false;
            }
            int index = (int)value;
            int parIndex = Int32.Parse((string)parameter);
            return index == parIndex;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null || (bool)value == false)
            {
                return -1;
            }
            return Int32.Parse((string)parameter);   
        }
    }
