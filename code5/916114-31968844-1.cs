    internal class ErrorCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            return new ListBox
            {
                ItemsSource = (ReadOnlyObservableCollection<ValidationError>)value,
                BorderThickness = new Thickness(0),
                Background = Brushes.Transparent,
                DisplayMemberPath = "ErrorContent"
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }	
