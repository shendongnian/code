    <Button Content="Copy" Command="{Binding LinkCopyCommand, UpdateSourceTrigger=PropertyChanged}" >
    <Button.ContextMenu>
        <ContextMenu>
           <MenuItem Header="Copy Download link " Command="{Binding Path=CopyViewCommand}" />
           <MenuItem ... />
        </ContextMenu>
    </Button.ContextMenu> 
