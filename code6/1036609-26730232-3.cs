    public class SelectedNamesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((List<string>)value.length() == 0):
                return "Please select";
            if (((List<string>)value).length() == ((List<string>)parameter).length())
                return "All people";
            return "Specific selection";
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Log this as a non-fatal error.  You shouldn't be here!
            return DependencyProperty.UnsetValue;
            // Alternatively:
            // throw new NotImplementedException();
        }
    }
