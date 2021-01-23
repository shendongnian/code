    <TreeView ItemsSource="{Binding ClassList}">
        <TreeView.ItemContainerStyle>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="IsExpanded" Value="{Binding Path=IsExpanded, Mode=TwoWay}"/>
            </Style>
        </TreeView.ItemContainerStyle>
        <TreeView.Resources>
            <HierarchicalDataTemplate DataType="{x:Type loc:Class}" ItemsSource="{Binding Students}">
                <StackPanel Orientation="Horizontal">
                    <Image Margin="2" Source="{Binding ImagePath}">
                    </Image>
                    <TextBlock Margin="2" Text="{Binding Name}">
                    </TextBlock>
                </StackPanel>
            </HierarchicalDataTemplate>
            <HierarchicalDataTemplate DataType="{x:Type loc:Student}">
                <StackPanel Orientation="Horizontal">
                    <Image Margin="2" Source="{Binding ImagePath}">
                    </Image>
                    <TextBlock Margin="2" Text="{Binding Name}" ToolTip="{Binding ToolTip}">
                    </TextBlock>
                </StackPanel>
            </HierarchicalDataTemplate>
        </TreeView.Resources>
    </TreeView>
