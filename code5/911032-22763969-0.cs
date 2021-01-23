     public sealed class BoolToVisibilityConverter : IValueConverter
    {
        #region Methods
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            bool boolValue = false;
            if (!bool.TryParse(System.Convert.ToString(value), out boolValue))
            {
                boolValue = false;
            }
            if (boolValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
        
        #endregion
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
