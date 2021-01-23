XAML
    <Button Content="{Binding ResourceKey, Converter={StaticResource resourceConverter}}" />
	
Code behind
    public class StaticResourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var resourceKey = (string)value;
			
            // Here you can add logic
			
            return Application.Current.Resources[resourceKey];
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }	
