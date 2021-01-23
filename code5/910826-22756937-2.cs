        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <DataTemplate.Resources>
                    <myns:ConvertToFormatedRuns xmlns:myns="clr-namespace:YourProjectName" />
                </DataTemplate.Resources>
                <Label>
                    <Label.Content>
                        <MultiBinding Converter={StaticResource ConvertToFormatedRuns}>
                            <Binding Path="xxx" />
                            <Binding Path="yyy" />
                        </MultiBinding>
                    </Label.Content>
                </Label>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
     
    **CODE**
        public class ConvertToFormatedRuns : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                var tb = new TextBlock();
        
                tb.Inlines.Add(new Run() { Text = (string)values[0], Background = Brushes.Yellow });
                tb.Inlines.Add(new Run() { Text = (string)values[1]});
        
                return tb;
            }
        }
