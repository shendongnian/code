    <UserControl.Resources>
        <ResourceDictionary>
            <local:DateToColorConverter x:Key="DateToColorConverter"/>
        </ResourceDictionary>
    </UserControl.Resources>
    ...
    <TextBlock Name="activityDateCreated"
        Text="{Binding DateCreated, StringFormat='Stworzono: {0}'}"                                  
        Margin="10"
        Foreground="{Binding Deadline, Converter={StaticResource DateToColorConverter}" />
    ...
    Your Converter (put this in your code behind)...
    public class DateToColorConverter : IValueConverter
    {
        static SolidColorBrush _normalColor = new SolidColorBrush(Colors.Black);
        static SolidColorBrush _pastDeadlineColor = new SolidColorBrush(Colors.Red);
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                var deadline = value as DateTime;
                return deadline < DateTime.Now ? _pastDeadlineColor : _normalColor;
            }
            return _normalColor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
