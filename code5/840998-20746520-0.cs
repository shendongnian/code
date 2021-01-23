    <Grid Grid.Row="2" IsEnabled="{Binding 
        ElementName=dgCustomers, Path=SelectedItem, 
        Converter={StaticResource NullToFalseConverter}">
    public class NullToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? false : true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
