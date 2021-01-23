        namespace WpfApplication1
        {
            public class CheckedStatusToTextConverters : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    bool checkedStatus = (bool)value;
                    return checkedStatus ? "Uncheck All" : "Check All";
                }
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotSupportedException();
                }
            }
        }
