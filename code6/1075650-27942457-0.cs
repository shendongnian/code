    <DataGrid     
        ItemsSource="{Binding AvailableNetworkInterfaces}"   
        SelectedItem="{Binding SelectedItemProperty}">
    <DataGrid.Columns>
    <DataGridTemplateColumn Width="100" x:Name="ColumnCosts">
        <DataGridTemplateColumn.Header>
           <Stackpanel>
              <TextBlock Text="Costs"/>
              <Image Source="...\" />
           </Stackpanel>
        </DataGridTemplateColumn.Header
        <DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
                <TextBox Width="80" Text="{Binding Dollar, Mode=OneWay}"/>
            </DataTemplate>
        </DataGridTemplateColumn.CellTemplate>
    </DataGridTemplateColumn>
    </DataGrid.Columns>
