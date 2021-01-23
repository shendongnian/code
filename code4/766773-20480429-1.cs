        <sdk:DataGrid Grid.Row="1" ItemsSource="{Binding People}" AutoGenerateColumns="False" KeyDown="DataGrid_KeyDown">
            <sdk:DataGrid.Columns>
                <sdk:DataGridTemplateColumn>
                    <sdk:DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding FirstName}" />
                        </DataTemplate>
                    </sdk:DataGridTemplateColumn.CellEditingTemplate>
                </sdk:DataGridTemplateColumn>
                <sdk:DataGridTemplateColumn>
                    <sdk:DataGridTemplateColumn.CellEditingTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding LastName}" />
                        </DataTemplate>
                    </sdk:DataGridTemplateColumn.CellEditingTemplate>
                </sdk:DataGridTemplateColumn>
            </sdk:DataGrid.Columns>
        </sdk:DataGrid>
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                DataGrid dg = (DataGrid)sender;
                dg.SelectedIndex++;
                dg.CurrentColumn = dg.Columns[0];
                dg.BeginEdit();
                var cell = dg.CurrentColumn.GetCellContent(dg.SelectedItem);
            }
        }
