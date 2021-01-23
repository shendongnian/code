    public class AttributeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter as string != null)
            {
                var property = value.GetType().GetProperty((string)parameter);
                if (property != null)
                {
                    var attribute = property.GetCustomAttributes(typeof(ValuesAttribute), false).OfType<ValuesAttribute>().FirstOrDefault();
                    if (attribute != null)
                        return attribute.values.Select((display, index) => 
                            new KeyValuePair<int, string>(index, display)
                            ).ToArray();
                }
            }
            return DependencyProperty.UnsetValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
