    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(bool)) return null;
            bool boolValue = IsInverted ? !(bool)value : (bool)value;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(Visibility)) return null;
            if (IsInverted) return (Visibility)value != Visibility.Visible;
            return (Visibility)value == Visibility.Visible;
        }
    }
