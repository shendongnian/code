    class MessageCodeToMessageConverter : IMultiValueConverter
    {
    public object Convert(object[] values, Type targetType, object parameter,     System.Globalization.CultureInfo culture)
    {
        FrameworkElement targetObject = values[0] as FrameworkElement;
        if (targetObject == null)
        {
           return DependencyProperty.UnsetValue;
        }
        if (value != null)
        {
            string messageCode = (string)values[1];
            try
            {
                return targetObject.FindResource(messageCode);
            }
            catch (Exception)
            {
                return messageCode;
            }
        }
        else
        {
            return null;
        }
    }
    public object ConvertBack(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return "";
    }
    }
