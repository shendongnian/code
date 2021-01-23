    <TreeView ItemsSource="{Binding Folders, UpdateSourceTrigger=PropertyChanged}" x:Name="tree">
        <TreeView.InputBindings>
            <KeyBinding Key="Delete" Command="{Binding DataContext.DeleteFolderCommand, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl}}"/>
        </TreeView.InputBindings>
        <TreeView.ItemTemplate>
            <HierarchicalDataTemplate ItemsSource="{Binding Folders, UpdateSourceTrigger=PropertyChanged}">
                <Label Content="{Binding Name}">
                    <Label.InputBindings>
                        <MouseBinding MouseAction="LeftDoubleClick"
                                    Command="{Binding DataContext.SelectFolderCommand, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl}}"
                                    CommandParameter="{Binding ElementName=tree, Path=SelectedItem}" />
                    </Label.InputBindings>
                </Label>
            </HierarchicalDataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
