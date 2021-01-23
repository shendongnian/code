      <StackPanel Orientation="Horizontal" VerticalAlignment="Center" Width="125">
        <TextBox Text="Lie" Name="Label1" MaxWidth="{Binding RelativeSource={RelativeSource AncestorType=StackPanel}, Path=Width}"/>
        <Border Background="CadetBlue" Height="5">
            <Border.Width>
                <MultiBinding Converter="{StaticResource Converter}">
                    <Binding RelativeSource="{RelativeSource AncestorType=StackPanel}" Path="Width"/>
                    <Binding ElementName="Label1" Path="ActualWidth"/>
                </MultiBinding>
            </Border.Width>
        </Border>
      </StackPanel>
    [ValueConversion(typeof(double), typeof(double))]
    public class MyConverterS : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double panelWidth, elementWidth;
            Double.TryParse(values[0].ToString(), out panelWidth);
            Double.TryParse(values[1].ToString(), out elementWidth);
            if (panelWidth - elementWidth <= 0)
                return 0;
            return panelWidth - elementWidth;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
