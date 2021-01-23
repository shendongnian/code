    public class BooleanToVisibilityConverter : IValueConverter
    {
        public Visibility VisibilitIfTrue { get;set; }
        public Visibility VisibilitIfFalse { get;set; }
        public BooleanToVisibilityConverter()
        {
            // Set default values for the most common usage
            VisibilityIfTrue = Visible;
            VisibilityIfFalse = Collapsed;
        }
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
        
        // Converter could be extended to handle nullable bools as well, but ignore for now
        if (value == null)
        {
            return DependencyProperty.UnsetValue;
        }
        // value should be of type bool
        bool b = (bool)value;
        if (b == true)
        {
            return VisibilityIfTrue;
        }
        else
        {
            return VisibilityIfFalse;
        }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
             throw new NotImplementedException(); // Not necessary
        }
    }
