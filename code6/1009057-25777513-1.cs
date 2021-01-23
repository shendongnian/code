        <TreeView ItemsSource="{Binding Drives}">
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Folders}">
                    <TextBlock Text="{Binding Name}"></TextBlock>
                    <HierarchicalDataTemplate.ItemContainerStyle>
                        <Style TargetType="TreeViewItem">
                            <Setter Property="IsExpanded" Value="{Binding IsExpanded,Mode=TwoWay}" />
                        </Style>
                    </HierarchicalDataTemplate.ItemContainerStyle>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
