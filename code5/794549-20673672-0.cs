    public class MessageBackgroundConverter : BaseConverter, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null)
            {
                var postedByUserId = Guid.Parse(values[0].ToString());
                var loggedInUserId = Guid.Parse(values[1].ToString());
                var control = values[2] as Border;
                if (control != null)
                {
                    if (postedByUserId == loggedInUserId)
                    {
                        control.SetResourceReference(Border.BackgroundProperty, VsBrushes.CommandBarGradientKey);
                        return null;
                    }
                    control.SetResourceReference(Border.BackgroundProperty, VsBrushes.ToolWindowBackgroundKey);
                    return null;
                }
            }
            return Brushes.Transparent;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
