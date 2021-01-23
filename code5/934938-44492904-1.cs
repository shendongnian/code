    [ValueConversion(typeof(ValidationError), typeof(bool))]
    class TxtBoxMultiEnableConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int i=0;
            foreach (var item in values)
            {
                if (item as ValidationError != null)
                {
                    i++;
                }
            }
            if (i!=0)
            {
                return false;
            }
            return true;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
