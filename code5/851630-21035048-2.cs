    public class VisibilityToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            var visible = (Visibility)value;
            return visible == Visibility.Visible
                ? new SolidColorBrush(System.Windows.Media.Color.FromRgb(70, 130, 180))
                : new SolidColorBrush(System.Windows.Media.Color.FromRgb(173, 216, 230));
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
