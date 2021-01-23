       <DataGrid x:Name="CardViewer" AutoGenerateColumns="False" CanUserResizeColumns="False" 
              CanUserResizeRows="False" CanUserSortColumns="False" CanUserAddRows="False" Grid.Column="0" 
              ItemsSource="{Binding}">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Cards" Width="*">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ItemsControl ItemsSource="{Binding}" >
                            <ItemsControl.ItemTemplate>
                                <DataTemplate>
                                       <StackPanel Orientation="Vertical" HorizontalAlignment="Center">
                            <Image Source="{Binding CardImage}" Height="50" Width="50"/>
                            <Label Content="{Binding Name}"/>
                        </StackPanel> 
                                </DataTemplate>
                            </ItemsControl.ItemTemplate>
                            <ItemsControl.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <VirtualizingStackPanel Orientation="Horizontal"/>
                                </ItemsPanelTemplate>
                            </ItemsControl.ItemsPanel>
                        </ItemsControl>
                    
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
