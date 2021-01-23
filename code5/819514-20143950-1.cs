    <Window.Resources>
                <local:BrushColorConverter x:Key="BConverter"></local:BrushColorConverter>
    </Window.Resources>
    ...
    <GroupBox>
        <GroupBox.Header>
          <Label Foreground="{Binding ElementName=AnswerButton,Path=IsEnabled, Converter={StaticResource BConverter}}">My Group Header Label</Label>
        </GroupBox.Header>
    </GroupBox>
    public class BrushColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return System.Windows.Media.Colors.Gray;
                }
            }
            return System.Windows.Media.Colors.Black;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
    }
