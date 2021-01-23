    namespace WpfApplication1
    {
        class CoverterItemsSource2Enabled : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null)
                    return false;
                if(value is ItemCollection)
                {
                    if ((value as ItemCollection).Count > 0)
                        return true;
                }
                return false;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
