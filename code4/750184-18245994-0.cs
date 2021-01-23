    <HierarchicalDataTemplate DataType="{x:Type local:FirstTierType}" ItemsSource="{Binding Items}">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="{Binding Name}"  />
        </StackPanel>
    </HierarchicalDataTemplate>
    <DataTemplate DataType="{x:Type local:SecondTierType}">
        <StackPanel Orientation="Horizontal">
            <TextBlock Text="{Binding Name}"  />
            <StackPanel.ContextMenu>
                <ContextMenu>
                   <MenuItem Header="whatever1" Command="whatever1cmd"></MenuItem>
                   <MenuItem Header="whatever2" Command="whatever2cmd"></MenuItem>
                   <MenuItem Header="whatever3" Command="whatever2cmd"></MenuItem>
                </ContextMenu>
            </StackPanel.ContextMenu>
        </StackPanel>
    </DataTemplate>
    .
    .
    .
    <TreeView ItemsSource="{Binding Items}" />
