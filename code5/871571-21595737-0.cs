    <Button Content="Copy" Tag="{Binding LinkViewModel, RelativeSource={RelativeSource Mode=Self}}" Command="{Binding LinkCopyCommand, UpdateSourceTrigger=PropertyChanged}" >
    <Button.ContextMenu>
        <ContextMenu>
           <MenuItem Header="Copy Download link " Command="{Binding Path=PlacementTarget.Tag.CopyViewCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}" />
           <MenuItem ... />
        </ContextMenu>
    </Button.ContextMenu> 
