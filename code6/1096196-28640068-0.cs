    <Grid>
        <Grid.Resources>
            <ItemsPanelTemplate x:Key="GlobalMenuItemPanelTemplate">
                <StackPanel Margin="-25,0,0,0" Background="White"/>
            </ItemsPanelTemplate>
            <Style TargetType="{x:Type ContextMenu}">
                <Setter Property="ItemsPanel" Value="{StaticResource GlobalMenuItemPanelTemplate}"/>
            </Style>
        </Grid.Resources>
        <Label Background="Bisque" Content="Right Click it" VerticalAlignment="Center" HorizontalAlignment="Center">
            <Label.ContextMenu>
                <ContextMenu>
                    <MenuItem Header="Menu item 1" />
                    <MenuItem Header="Menu item 2" />
                    <Separator />
                    <MenuItem Header="Menu item 3" />
                </ContextMenu>
            </Label.ContextMenu>
        </Label>
    </Grid>
