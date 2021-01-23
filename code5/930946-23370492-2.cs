        public class BoolToButtonStyleConverter : IValueConverter
        {
            public object Convert(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                bool someValue = (bool)value;
                if (someValue)
                    return parameter;
                else
                    return Application.Current.Resources["clearStyle"];
            }
            public object ConvertBack(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                return true;
            }
        } 
