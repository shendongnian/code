        <DataGrid ItemsSource="{Binding MyView}">
            <DataGrid.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="Show/ Hide">
                        <StackPanel>
                            <ItemsControl ItemsSource="{Binding RelativeSource={RelativeSource AncestorType=ContextMenu}, Path=PlacementTarget.Columns, Mode=OneWay}">
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate DataType="{x:Type DataGridColumn}">
                                        <CheckBox Content="{Binding Path=Header, Mode=OneWay}" 
                                                  IsChecked="{Binding Path=Visibility, Converter={StaticResource TrueIfVisibleConverter}}"/>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </StackPanel>
                    </MenuItem>
                </ContextMenu>
            </DataGrid.ContextMenu>
          </DataGrid>
