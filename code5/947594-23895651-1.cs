     public class BooleanVisibilityConverter : IValueConverter
     {
        private const string REVERSE = "Reverse";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Visibility)) throw new InvalidOperationException();
            // reverse
            if (parameter != null && parameter.ToString().Equals(REVERSE, StringComparison.InvariantCultureIgnoreCase))
            {
                return (((bool)value) ? Visibility.Collapsed : Visibility.Visible);
            }
            else
            {
                return (((bool)value) ? Visibility.Visible : Visibility.Collapsed);
            }
        }
    }
