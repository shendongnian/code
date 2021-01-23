    public class MyUnitConverter : DependencyObject, IValueConverter
    {
        // add dependency property ClassName as string
        public object Convert(object value, Type targetType, object parameter, CultureInfo info)
        {
            // use dependency property ClassName and (string)parameter 
            // as property name to get the attribute values using Reflection.
        }
    }
