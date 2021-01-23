    public class IsCurrentCycleColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush color = new SolidColorBrush(Colors.Black);
            if (values != null && values.Count() == 3)
            {
                var itemsSource = values[0] as ObservableCollection<BillingCycle>;//This is the Type of you Collection binded to ItemsSource
                if (!(itemsSource != null && itemsSource.Any() && itemsSource.First() == (BillingCycle)values[1] && values[2] == values[1]))
                {
                    color = new SolidColorBrush(Colors.DarkRed);
                }
            }
            return color;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
