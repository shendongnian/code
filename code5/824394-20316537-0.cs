    <HierarchicalDataTemplate ItemsSource="{Binding Childs}"
                              DataType="{x:Type viewmodels:TreeListViewModel+Node}">
        <StackPanel Orientation="Horizontal">
            <StackPanel.ContextMenu>
                <ContextMenu cal:Action.TargetWithoutContext="{Binding DataContext, RelativeSource={RelativeSource Self}}">
                    <MenuItem Header="Cut" cal:Message.Attach="Cut" />
                    <MenuItem Header="Copy" cal:Message.Attach="Copy" />
                    <MenuItem Header="Paste" cal:Message.Attach="Paste" />
                </ContextMenu>
            </StackPanel.ContextMenu>
            <TextBlock Text="{Binding Name}" />
        </StackPanel>
    </HierarchicalDataTemplate>
