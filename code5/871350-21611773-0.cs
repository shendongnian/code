        <TreeView Grid.ColumnSpan="2" Grid.RowSpan="2">
            <TreeViewItem Header="Routes" Name="RouteView" ItemsSource="{Binding Routes}">
                <TreeViewItem.ItemTemplate>
                    <HierarchicalDataTemplate DataType="{x:Type viewModels:RouteViewModel}"  ItemsSource="{Binding}">
                        <StackPanel Orientation="Horizontal">
                            <Label Content="{Binding Path=Name}" VerticalAlignment="Center"></Label>
                        </StackPanel>
                    </HierarchicalDataTemplate>
                </TreeViewItem.ItemTemplate>
            </TreeViewItem>
        </TreeView>
