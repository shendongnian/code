    <UserControl>
       <UserControl.Resources>
           <LoggingStyleConverter x:Key="LoggingStyleConverter" />
       </UserControl.Resources>
       <TextBox
            Text="{Binding Path=Foo.Bar.LoggingService.Text}"
            Style="{Binding Path=Foo.Bar.LoggingService.Type 
                      Converter={StaticResource LoggingStyleConverter}}"
       />
    </UserControl>
    public class LoggingStyleConverter : IValueConverter
    {
        public object Convert(object value, blah blah blah)
        {
            var type = (LoggingTypes)value;
            switch (type)
            {
                case blah:
                    return SomeStyle;
                default:
                    return SomeOtherStyle;
            }
        }
    }
