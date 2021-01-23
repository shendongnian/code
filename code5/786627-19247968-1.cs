    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding Program}">
            <DataGrid.Columns>
                <DataGridTemplateColumn>
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <ListBox ItemsSource="{Binding parameters}">
                              <ListBox.ItemsPanel>
                                  <ItemsPanelTemplate>
                                      <StackPanel IsItemsHost="True" Orientation="Horizontal"/>
                                  </ItemsPanelTemplate>
                              </ListBox.ItemsPanel>
                            </ListBox>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
        </DataGrid>
