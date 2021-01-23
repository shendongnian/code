    [ValueConversion(typeof(int), typeof(bool))]
    public class StatusToEnabledConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int status = (int)value;
            switch (status)
            {
                case 1: return true;
                case 2: return false;
                default: return false;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
