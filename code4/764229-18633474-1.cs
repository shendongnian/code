    <DataGrid ItemsSource="{Binding Data}" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Layer name" Binding="{Binding LayerName}" />
            <DataGridTextColumn Header="Porosity" Binding="{Binding Porosity}" />
            <DataGridCheckBoxColumn Header="Accept" Binding="{Binding Accept, UpdateSourceTrigger=PropertyChanged}" />
        </DataGrid.Columns>
    </DataGrid>
