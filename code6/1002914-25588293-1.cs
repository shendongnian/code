    public class ReferencesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == DependencyProperty.UnsetValue)
                return DependencyProperty.UnsetValue;
            var collection = (ReadOnlyObservableCollection<object>)value;
            var updateEntries = collection.Cast<UpdateEntry>();
            // TODO Return number of references
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
