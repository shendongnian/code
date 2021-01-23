       <Setter Property="ToolTip" Value="{Binding Converter={StaticResource MyConverter}" />
        public class MyConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                //Create your string here from properties
                return tooltiptext;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return value;
            }
        }
