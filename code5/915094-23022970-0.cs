    <DataTemplate>
        <StackPanel>
            <toolkit:ContextMenuService.ContextMenu>
                <toolkit:ContextMenu>
                    <toolkit:MenuItem Header="add to favourites" Visibility="{Binding isFavorite, Converter={StaticResource BoolToVisibility}}" Tap="HandleFavouriteTap"/>
                    <toolkit:MenuItem Header="remove from favourites" Visibility="{Binding isFavorite, Converter={StaticResource BoolToCollapsed}}" Tap="HandleFavouriteTap"/>
                </toolkit:ContextMenu>
            </toolkit:ContextMenuService.ContextMenu>
            <Grid Width="420">
                ...
            </Grid>
        </StackPanel>
    </DataTemplate>
