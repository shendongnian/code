    public class DisplayNameAnnotationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                // for Windows 8, need Type.GetTypeInfo()
                // http://msdn.microsoft.com/en-us/library/windows/apps/br230302%28v=VS.85%29.aspx#reflection
                var prop = value.GetType().GetTypeInfo().GetProperty((string)parameter);
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
