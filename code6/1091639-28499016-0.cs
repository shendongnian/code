    <DataGrid>
       <DataGrid.Columns>
          <DataGridTemplateColumn>
                        <DataGridTemplateColumn.CellTemplate>
                            <DataTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{Binding Path=AttrName}" Height="25" Width="150" HorizontalAlignment="Left" VerticalAlignment="Top" />
                                    <TextBlock Text="{Binding Path=AttrDisplayLabel}" Height="25" Width="Auto" HorizontalAlignment="Right" VerticalAlignment="Top" Margin="10,0,0,0" />
                                </StackPanel>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellTemplate>
                        <DataGridTemplateColumn.CellEditingTemplate>
                            <DataTemplate>
                                <ComboBox Height="25" 
                                          ItemsSource="{Binding Source={StaticResource cvsAttributes}}"
                                          SelectedValuePath="AttributeID"
                                          IsSynchronizedWithCurrentItem="False"
                                          SelectionChanged="Selector_OnSelectionChanged"
                                          SelectedValue="{Binding Path=AttributeId, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                                    
                                    <ComboBox.ItemTemplate>
                                        <DataTemplate>
                                            <StackPanel Orientation="Horizontal">
                                                <TextBlock Text="{Binding Name}"/>
                                            </StackPanel>
                                        </DataTemplate>
                                    </ComboBox.ItemTemplate>
                                    
                                    <ComboBox.ItemsPanel>
                                        <ItemsPanelTemplate>
                                            <VirtualizingStackPanel />
                                        </ItemsPanelTemplate>
                                    </ComboBox.ItemsPanel>
                                    
                                </ComboBox>
                            </DataTemplate>
                        </DataGridTemplateColumn.CellEditingTemplate>
                    </DataGridTemplateColumn>
     ....
