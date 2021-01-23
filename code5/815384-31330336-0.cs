    public class EnumValuesConverter : IValueConverter
    {
        /// <summary>
        /// Converts the given value into a collection of enum values
        /// </summary>
        /// <returns>collection of strings</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                IEnumerable<Enum> enumsCollection = value.GetType().GetEnumValues().Cast<Enum>();
                return enumsCollection;
            }
            return null;
        }
        /// <summary>
        /// Converts back a given value. Not supported for this converter.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("EnumValuesConverter is a OneWay converter.");
        }
    }
