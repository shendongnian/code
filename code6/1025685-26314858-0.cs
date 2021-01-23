    <DataGrid>
        <DataGrid.Resources>
            <Style TargetType="{x:Type DataGridColumnHeader}">
                <EventSetter Event="Click"
                             Handler="GridViewColumnHeaderClickedHandler"/>
            </Style>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn Header="Table">
                <DataGridTextColumn.HeaderStyle>
                    <Style TargetType="DataGridColumnHeader"
                           BasedOn="{StaticResource {x:Type DataGridColumnHeader}}">
                        <EventSetter Event="PreviewMouseMove" 
                                     Handler="DataGridHeader_PreviewMouseMove"/>
                    </Style>
                </DataGridTextColumn.HeaderStyle>
            </DataGridTextColumn>
            .........
        </DataGrid.Columns>
    </DataGrid>
