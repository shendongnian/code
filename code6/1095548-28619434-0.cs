<ComboBox Style="{StaticResource ComboButtonStyle}" Width="200" ItemsSource="{Binding XPath=@Choices, Converter={StaticResource StringToListConverter}}" IsEditable="True" />
    [ValueConversion(typeof(string), typeof(List<string>))]
    public class StringToListConverter : IValueConverter
    {
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(List<string>))
                throw new InvalidOperationException("The target must be a List<string>");
    
            return new List<string>(((string)value).Split(';'));
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
