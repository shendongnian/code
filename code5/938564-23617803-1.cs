    <StackPanel Orientation="Vertical" Margin="0,20">
        <StackPanel.ContextMenu>
            <ContextMenu ItemsSource="{Binding ContextMenuItems}">
                <ContextMenu.ItemContainerStyle>
                    <Style TargetType="{x:Type MenuItem}">
                        <Setter Property="Header" Value="{Binding Caption}"/>
                        <Setter Property="Command" Value="{Binding Command}"/>
                    </Style>
                </ContextMenu.ItemContainerStyle>
            </ContextMenu>
        </StackPanel.ContextMenu>
        <!-- ... -->
    </StackPanel>
