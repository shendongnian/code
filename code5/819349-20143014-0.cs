    <Menu FontFamily="Segoe UI" Background="#FF3C454F" TextElement.Foreground="White">
        <Menu.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Orientation="Vertical"/>
            </ItemsPanelTemplate>
        </Menu.ItemsPanel>
        <Menu.Resources>
            <Style TargetType="MenuItem">
                <Setter Property="Padding" Value="40, 20" />
            </Style>
        </Menu.Resources>
        <MenuItem Header="COMPUTER">
            <MenuItem Header="WEBSITE" />
            <MenuItem Header="VIRTUAL MACHINE" />
            <MenuItem Header="MOBILE SERVICE" />
        </MenuItem>
        <MenuItem Header="DATA SERVICES">
            <MenuItem Header="WEBSITE" />
            <MenuItem Header="VIRTUAL MACHINE" />
            <MenuItem Header="MOBILE SERVICE" />
        </MenuItem>
        <MenuItem Header="NETWORK SERVICES">
            <MenuItem Header="WEBSITE" />
            <MenuItem Header="VIRTUAL MACHINE" />
            <MenuItem Header="MOBILE SERVICE" />
        </MenuItem>
    </Menu>
