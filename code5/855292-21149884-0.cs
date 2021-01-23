    <Button Tag="{Binding DataContext, RelativeSource={RelativeSource AncestorType={x:Type 
        Views:YourView}}}">
        <Button.ContextMenu>
            <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource={
                RelativeSource Self}}">
                <MenuItem />
                <MenuItem Name="myMenuItem" Command="{Binding DoAction}" 
                    CommandParameter="{Binding SelectedItems}" />
            </ContextMenu>
        </Button.ContextMenu>
    </Button>
