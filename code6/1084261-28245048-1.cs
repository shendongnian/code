    class IndexToBoolConverter : IValueConverter
    {
        #region IValueConverter Members
    
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
                if (parameter != null && (int)value == (int)parameter)
                {
                    return true;
                }
                else
                    return false;
        }
    
        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value == true)
                return false;
            else
                return true;
        }
    
        #endregion
    }
