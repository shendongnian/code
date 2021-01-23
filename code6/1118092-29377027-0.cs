    public class MultiBrushColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Debug.WriteLine("Simple Converter Called: " + values[0] + " , " + values[0]);
            var textBlock = values[1];
            if ((int)values[0] < 18) return new SolidColorBrush(Color.FromRgb(250, 0, 0));
            if (60 > (int)values[0] && (int)values[0] > 18) return new SolidColorBrush(Color.FromRgb(0, 250, 0));
            return new SolidColorBrush(Color.FromRgb(0, 0, 250));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    <DataGridTemplateColumn Header="Age" IsReadOnly="True">
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <TextBlock Name="Age" Text="{Binding Path=Age}" MouseLeftButtonDown="OnCellMouseLeftButtonDown">
                    <TextBlock.Background>
                        <MultiBinding Converter="{StaticResource MultiColorConverter}">
                            <Binding Path="Age" />
                            <Binding RelativeSource="{RelativeSource Self}" />
                        </MultiBinding>
                    </TextBlock.Background>
                 </TextBlock>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
