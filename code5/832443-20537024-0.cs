    <DataGrid ItemsSource="{Binding SearchResult, ElementName=PageTitle}" Width="350">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.Header>
                        <TextBlock Text="{Binding ColumnNames/ColumnName, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"></TextBlock>
                    </DataGridTemplateColumn.Header>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
    </DataGrid>
