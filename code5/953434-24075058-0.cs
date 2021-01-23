     <DataGrid AutoGenerateColumns="False" Name="tstgrid"
              ItemsSource="{Binding OrderItems}"
               >
              <DataGrid.Columns>
                 <DataGridTemplateColumn Width="200" Header="Item">
                     <DataGridTemplateColumn.CellTemplate>
                          <DataTemplate>
                               <TextBlock Text="{Binding ProductName,Mode=OneWay}"/>
                </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                            <DataTemplate>
                                <ComboBox>
                                    <vw:CustomDatagrid  />
                                </ComboBox>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellEditingTemplate>
                </DataGridTemplateColumn>
                </DataGrid.Columns>
      </DataGrid>
