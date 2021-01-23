    <DataGrid ItemsSource="{Binding Numbers}" MouseDoubleClick="DataGrid_MouseDoubleClick">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding}" />
        </DataGrid.Columns>
    </DataGrid>
