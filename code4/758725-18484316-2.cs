    public class NameToBarkConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dog = value as Dog;
            if (dog != null)
            {
                return dog.BarkYourName();
            }
            return value.ToString();
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
