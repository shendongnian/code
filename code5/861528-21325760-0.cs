    public class DisplayNameAnnotationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var prop = value.GetType().GetProperty((string)parameter);
                if (prop != null)
                {
                    var att = prop.GetCustomAttributes(false).OfType<DisplayAttribute>().FirstOrDefault() as DisplayAttribute;
                    if (att != null)
                        return att.DisplayName;
                }
            }
            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
