    <TreeView ItemsSource="{Binding MyCollectionOfItems}">
        <TreeView.Resources>
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
                <Setter Property="Header" Value="{Binding HeaderText}" />
            </Style>
        </TreeView.Resources>
    </TreeView>
