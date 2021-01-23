        public class ComboBoxForegroundConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Count() == 3)
            {
                var itemsSource = values[0] as ObservableCollection<UserType>;//This is the Type of you Collection binded to ItemsSource
                if (itemsSource != null && itemsSource.Any() && itemsSource.Last() == values[1] && values[2]==values[1])
                    return new SolidColorBrush(Colors.Red);
            }
            return new SolidColorBrush(Colors.Black);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
