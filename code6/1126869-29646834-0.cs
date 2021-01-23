    /// <summary>
    /// Converts a bool to it's oppisite and back.
    /// </summary>
    public sealed class NotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (!(value is bool)) || !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (value is bool) && (bool)value;
        }
    }
