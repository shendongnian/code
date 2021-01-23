    public class ThemeToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            var theme = (Theme)value;
            switch (theme.Value)
            {
                case Theme.Standard:
                    return new SolidColorBrush(Colors.Transparent);
                case Theme.Dark:
                    return new SolidColorBrush(153, 64, 76, 87);
                case Theme.Light:
                    return new SolidColorBrush(153, 00, 00, 00);
            }        
        }
        public object ConvertBack(object value, Type targetType, object parameter, 
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
