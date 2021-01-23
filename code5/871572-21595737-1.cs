    <Button Content="Copy" Tag="{Binding LinkViewModel, RelativeSource={RelativeSource Mode=Self}}" Command="{Binding LinkCopyCommand, UpdateSourceTrigger=PropertyChanged}" >
    <Button.ContextMenu>
        <ContextMenu>
           <MenuItem Header="Copy Download link " Command="{Binding Path=Tag.CopyViewCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Button}}" />
           <MenuItem ... />
        </ContextMenu>
    </Button.ContextMenu> 
