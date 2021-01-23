    namespace app.Converters
    {
        public class DimensionToText : IValueConverter
        {
            public object Convert(object value, Type targetType,
                object parameter, CultureInfo culture)
            {
                Dimensions dim = (Dimensions) value;
                //bool param = (bool) parameter;
                return dim.width.ToString().Trim() + "\"x " + dim.length.ToString().Trim() + "\"x " + dim.height.ToString().Trim() + "\"";
            }
    
            public object ConvertBack(object value, Type targetType,
                    object parameter, CultureInfo culture)
            {
                return value;
            }
        }
    }
