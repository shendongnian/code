    <Grid x:Name="myGrid" DataContext="topList">
        <Border BorderBrush="AliceBlue" Grid.Column="0" BorderThickness="5">
            <ItemsControl x:Name="ic1">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <StackPanel>
                            <Label Content="{Binding Path=TopName}"/>
                            <Border BorderBrush="AntiqueWhite" Grid.Column="1"    BorderThickness="5">
                                <DataGrid ItemsSource="{Binding Path=BottomList}" AutoGenerateColumns="False">
                                    <DataGrid.Columns>
                                        <DataGridTemplateColumn>
                                            <DataGridTemplateColumn.CellTemplate>
                                                <DataTemplate>
                                                    <Button Content="{Binding Path=BottomName}" Height="50"/>
                                                </DataTemplate>
                                            </DataGridTemplateColumn.CellTemplate>
                                        </DataGridTemplateColumn>
                                    </DataGrid.Columns>
                                </DataGrid>
                              </Border>
                        </StackPanel>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </Border>
    </Grid>
