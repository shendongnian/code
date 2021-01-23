       <TreeView ItemsSource="{Binding Path=Nodes}">
            <TreeView.Resources>
                <HierarchicalDataTemplate DataType="{x:Type local:Folder}"
                                          ItemsSource="{Binding Path=Children}">
                    <StackPanel>
                        <Label Content="{Binding Name}" />
                        <CheckBox Content="Selected"
                                  IsEnabled="False"
                                  IsChecked="{Binding RelativeSource={RelativeSource AncestorType=TreeViewItem}, Path=IsSelected, Mode=OneWay}" />
                    </StackPanel>
                </HierarchicalDataTemplate>
                <DataTemplate DataType="{x:Type local:File}">
                    <StackPanel>
                        <Label Content="{Binding Name}" />
                        <CheckBox Content="Selected"
                                  IsEnabled="False"
                                  IsChecked="{Binding RelativeSource={RelativeSource AncestorType=TreeViewItem}, Path=IsSelected, Mode=OneWay}" />
                    </StackPanel>
                </DataTemplate>
            </TreeView.Resources>
        </TreeView>
