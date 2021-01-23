    <ToggleButton Name="EditButton" Content="Edit" />
    ...
    <DataGrid ItemsSource="{Binding YourCollection}">
        <DataGrid.Columns>
            ...
            <DataGridTextColumn Header="Qty" IsReadOnly="{Binding IsQtyReadOnly}" 
                Binding="{Binding Qty}" />
            ...
        </DataGrid.Columns>
    </DataGrid>
