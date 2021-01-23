    <DataGrid x:Name="dataGridView">
        <DataGrid.Resources>
            <Style TargetType="DataGridRow">
                <EventSetter Event="MouseEnter" Handler="Row_MouseEnter"/>
            </Style>
        </DataGrid.Resources>
    </DataGrid>
    private void Row_MouseEnter(object sender, MouseEventArgs e)
    {
        int index = dataGridView.ItemContainerGenerator.IndexFromContainer((DataGridRow)sender);
    }
