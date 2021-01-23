    <ContextMenu DataContext="{Binding PlacementTarget.Tag, RelativeSource={
    RelativeSource Self}}">
        <MenuItem Header="Do Something" Command="{Binding YourCommandInYourViewModel}" 
    CommandParameter="{Binding YourCollection.CurrentItem}">
            ...
        </MenuItem>
    </ContextMenu>
