    <!-- CONTEXT MENU -->
    <Window.ContextMenu>
        <ContextMenu DataContext="MainWindowViewModel" Name="MainWindowContextMenu" PresentationTraceSources.TraceLevel="High">
            <MenuItem Header="Skins" ItemsSource="{Binding Source={StaticResource MainWindowViewModel}, Path=Skins}">
                <MenuItem.ItemContainerStyle>
                    <Style TargetType="MenuItem">
                        <Setter Property="Header" Value="{Binding Path=SkinName}"/>
                        <Setter Property="Command" Value="{Binding Source={StaticResource MainWindowViewModel}, Path=ContextMenuClickCommand}"/>
                        <Setter Property="CommandParameter" Value="{Binding Path=SkinName}"/>
                    </Style>
                </MenuItem.ItemContainerStyle>
            </MenuItem>
        </ContextMenu>
    </Window.ContextMenu>
