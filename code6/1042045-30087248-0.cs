                                        <DataGridTemplateColumn.CellTemplate>
                                            <DataTemplate>
                                                <ComboBox x:Name="vendorCombo"  ItemsSource="{Binding DataContext.VendorMasterSource, RelativeSource={RelativeSource AncestorType=Page}}"                                                     
                                                    SelectedValue="{Binding VendorNo,UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" 
                                                    SelectedValuePath="VENDOR_MASTER_ID"  
                                                            behaviour:ComboBoxSeletionChangedBehaviour.ComboBoxSeletionChangedCommand=
                                                      "{Binding DataContext.SelectionChangedCommand, RelativeSource={RelativeSource AncestorType=Page}}" TextSearch.TextPath="NAME"   IsTextSearchEnabled="True" IsEditable="True" >
                                                    <ComboBox.ItemTemplate>
                                                        <DataTemplate>
                                                            <StackPanel Orientation="Horizontal">
                                                                <TextBlock Text="{Binding Path=NUMBER}"/>
                                                                <TextBlock Text=" - "/>
                                                                <TextBlock Text="{Binding Path=NAME}"/>
                                                            </StackPanel>
                                                        </DataTemplate>
                                                    </ComboBox.ItemTemplate>
                                                </ComboBox>
                                            </DataTemplate>
                                        </DataGridTemplateColumn.CellTemplate>
                                    </DataGridTemplateColumn>
