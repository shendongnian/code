    <DataGrid ItemsSource="{Binding Persons, Mode=TwoWay}"
          SelectedItem="{Binding SelectedPerson, Mode=TwoWay}" >
        <DataGrid.Resources>
            <local:MyConverter x:Key="MyConverter"/>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Company" >
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <ComboBox ItemsSource="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}, Path=DataContext.Companies}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Company, Converter={StaticResource MyConverter}}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
    public class MyConverter : IValueConverter
    {
        public object Convert (object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }
            Type myType = value.GetType ();
            PropertyInfo pinfo = myType.GetProperty ("Name");
            if (pinfo == null)
            {
                return string.Empty;
            }
            return (string)pinfo.GetValue(value);
        }
        public object ConvertBack (object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
