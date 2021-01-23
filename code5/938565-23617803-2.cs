    <StackPanel Orientation="Vertical" Margin="0,20">
        <StackPanel.ContextMenu >
            <ContextMenu ItemsSource="{Binding ContextMenuItems}">
                <ContextMenu.ItemContainerStyle>
                    <Style TargetType="{x:Type MenuItem}">
                        <Setter Property="Command" Value="{Binding Command}"/>
                    </Style>
                </ContextMenu.ItemContainerStyle>
                <ContextMenu.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Caption}"/>
                    </DataTemplate>
                </ContextMenu.ItemTemplate>
            </ContextMenu>
        </StackPanel.ContextMenu>
        <!-- ... -->
    </StackPanel>
