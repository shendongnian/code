    public class AngleConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var angle = (int)value;
            if (angle != null)
            {
                return -angle;
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
