    <DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False" >
        <DataGrid.Columns>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
            <DataGridTemplateColumn Header="Item Collection">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ListBox ItemsSource="{Binding ItemCollection}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
