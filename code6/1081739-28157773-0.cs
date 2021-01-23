    <DataGrid Name="datagrid" AutoGenerateColumns="False" VirtualizingStackPanel.IsVirtualizing="True" VirtualizingStackPanel.VirtualizationMode="Recycling">
        <DataGrid.Columns>
            <DataGridTextColumn  Header="Title" Binding="{Binding Path=Name,NotifyOnTargetUpdated=True}" Width="300">
                <DataGridTextColumn.EditingElementStyle>
                    <Style TargetType="{x:Type TextBox}">
                        <EventSetter Event="LostFocus" Handler="Qty_LostFocus" />
                        <EventSetter Event="TextChanged" Handler="TextBox_TextChanged" />
                        <EventSetter Event="Binding.TargetUpdated" Handler="DataGridTextColumn_TargetUpdated"></EventSetter>
                    </Style>
                </DataGridTextColumn.EditingElementStyle>
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
