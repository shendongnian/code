    <DataGrid Name="dgUsers" AutoGenerateColumns="false">
                            <DataGrid.Columns  ItemsSource="{Binding ElementName=TestUC,
                                        Path=CustomerList}">
    
                                    <DataGridTextColumn Header="Name" Binding="{Binding Name}" />
    
                                    <DataGridTemplateColumn Header="Like">
                                            <DataGridTemplateColumn.CellTemplate>
                                                    <DataTemplate>
                                                            <Button Content="{Binding Like}" BorderThickness="0" />
                                                    </DataTemplate>
                                            </DataGridTemplateColumn.CellTemplate>
                                    </DataGridTemplateColumn>
    
                            </DataGrid.Columns>
                    </DataGrid>
    <TextBox x:Name="NameTextBox"
    Text="{Binding ElementName=TestUC, Path=FirstName, Mode=TwoWay}"
    Width="100"
    Height="25"
    Margin="0,10,0,10" />
