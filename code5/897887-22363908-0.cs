    <DataGrid AutoGenerateColumns="False" Name="m_gridControl">
        <DataGrid.Columns>
           <DataGridTextColumn x:Name="columnCategory" Width="10*">
                <!-- Additional Style -->
                <DataGridTextColumn.HeaderStyle>
                    <Style TargetType="DataGridColumnHeader">
                        <Setter Property="HorizontalContentAlignment" Value="Right"/>
                    </Style>
                </DataGridTextColumn.HeaderStyle>
                <!---------------------->
                <DataGridTextColumn.Header>
                    <StackPanel Orientation="Horizontal" x:Name="myStackPanel">
                        <TextBlock>Category</TextBlock>
                        <ComboBox x:Name="CategoryChooser"></ComboBox>
                    </StackPanel>
                </DataGridTextColumn.Header>
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
