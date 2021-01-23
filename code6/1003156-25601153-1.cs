       <DataTemplate>
            <Grid Background="{Binding IsSelected, Converter={StaticResource IsSelectedToBackgroundColorConverter}}">
                <TextBlock Text="{Binding displayName}" 
                           Style="{ThemeResource ListViewItemTextBlockStyle}" />
            </Grid>
       </DataTemplate>
|
    class IsSelectedToBackgroundColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool IsSelected = (bool)value;
            if (IsSelected)
            {
                Windows.UI.Xaml.Media.Brush red = new SolidColorBrush(Windows.UI.Colors.Red);
                return red;
            }
            else
            {
                Windows.UI.Xaml.Media.Brush transparent = new SolidColorBrush(Windows.UI.Colors.Transparent);
                return transparent;
            }
        }
           
    }
