    [ValueConversion(typeof(object), typeof(object))]
    class FlattenedPersonConverter: IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value == null || ((IEnumerable<Feature>)value).Count == 0)
            {
                return null;
            }
            else
            {
                return ((Feature)((IEnumerable<Feature>)value)[parameter.ToString()]).FeatureValue;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        #endregion
    }
