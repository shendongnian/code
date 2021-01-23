    <Button Content="Copy" Tag="{Binding LinkViewModel, RelativeSource={RelativeSource Mode=Self}}" Command="{Binding LinkCopyCommand, UpdateSourceTrigger=PropertyChanged}" >
            <Button.ContextMenu>
                <ContextMenu>
                   <MenuItem Header="Copy Download link " Command="{Binding RelativeSource={RelativeSource FindAncestor,  AncestorType={x:Type UserControl}}, Path=DataContext.CopyViewCommand}" />
                   <MenuItem ... />
                </ContextMenu>
            </Button.ContextMenu> 
        </Button>
