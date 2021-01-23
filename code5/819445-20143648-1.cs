    <ToggleButton Name="EditButton" Content="Edit" />
    ...
    <DataGrid ItemsSource="{Binding YourCollection}">
        <DataGrid.Columns>
            ...
            <DataGridTextColumn Header="Quantity" IsReadOnly="{Binding IsChecked, 
                ElementName=EditButton}" Binding="{Binding Quantity}" />
            ...
        </DataGrid.Columns>
    </DataGrid>
