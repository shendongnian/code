    <DataGrid Grid.Column="1" Margin="50" ItemsSource="{Binding Names}"
                CanUserAddRows="False" CanUserDeleteRows="False" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Path=.}" Width="*" Header="Names"/>
            <DataGridTemplateColumn Header="Edit" IsReadOnly="True">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Button Click="EditButton_InsideDataGrid_Click"
                                Style="{StaticResource EditSaveStyle}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
