    <ContextMenu ItemsSource="{Binding ContextMenuItemsSource}">
        <ContextMenu.ItemContainerStyle>
            <Style TargetType="MenuItem">
                <Setter Property="ItemsSource" Value="{Binding ContextMenuSubItems}"></Setter>
                <Setter Property="Header" Value="{Binding ContextMenuCommandHeader}"></Setter>
                <Setter Property="Command" Value="{Binding ContextMenuCommand}"></Setter>
            </Style>
         </ContextMenu.ItemContainerStyle>
    </ContextMenu>
