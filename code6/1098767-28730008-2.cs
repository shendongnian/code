    <Menu Grid.Row="1">
        <MenuItem Header="Uno" ItemsSource="{Binding Data.EstadosPausa}">
            <MenuItem.ItemContainerStyle>
                <Style TargetType="MenuItem">
                    <Setter Property="Header" Value="{Binding Estado}"/>
                    <Setter Property="Tag" Value="{Binding}" />
                </Style>
            </MenuItem.ItemContainerStyle>
        </MenuItem>
    </Menu>
