    public class BooleanToVisibilityConverter : IValueConverter
    {
        public bool IsNegation { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (this.IsNegation)
            {
                return (value is bool && (bool)value) ? Visibility.Collapsed : Visibility.Visible;
            }
            return (value is bool && (bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value is Visibility && (Visibility)value == Visibility.Visible;
        }
    }
