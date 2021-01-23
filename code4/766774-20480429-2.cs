    <Grid x:Name="LayoutRoot"  >
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <TextBox Grid.Row="0" Text="Some text" />
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
        <TextBox Grid.Row="2" Text="Some more text" />
    </Grid>
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            DataGrid dg = (DataGrid)sender;
            ObservableCollection<Person> items = dg.ItemsSource as ObservableCollection<Person>;
            if (e.Key == Key.Tab && dg.SelectedIndex < items.Count -1)
            {
                dg.SelectedIndex++;
                dg.CurrentColumn = dg.Columns[0];
                dg.BeginEdit();
                var cell = dg.CurrentColumn.GetCellContent(dg.SelectedItem);
            }
        }
