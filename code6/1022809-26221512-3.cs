    <TextBlock FontSize="{Binding Path=Text,
                                  Converter={StaticResource TabCountStringConverter}}"/> 
    public class TabCountStringConverter : IValueConverter
    {
        public object Convert(...)
        {
             return (value as String).Count(c => c == '\t'); //Count tabs
        }
        public object ConvertBack(...)
        {
             return Binding.DoNothing;
        }
    }
