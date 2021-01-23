    public class SelectedItemToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((parameter as Type).IsInstanceOfType(value))
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }
        public object ConvertBack(...)
        {
             return Binding.DoNothing;
        }
    }
