    namespace MyProjectName
    {
            public class VisibilityFormatter : IValueConverter
            {
                // Retrieve the format string and use it to format the value.
                public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    var visibility = parameter as bool?;
                    return visibility.HasValue && visibility.Value ? Visibility.Visible : Visibility.Collapsed;
                }
    
                // No need to implement converting back on a one-way binding 
                public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
        }
