    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        <Menu Name="menu1" >
            <MenuItem Header="File">
                <MenuItem Command="ApplicationCommands.New" Header="New" />
                <MenuItem Command="ApplicationCommands.Save" Header="Save" />
                <MenuItem Command="ApplicationCommands.Open" Header="Open" />
                <MenuItem Command="ApplicationCommands.Close" Header="Exit" />
            </MenuItem>
            <MenuItem Header="Stuff">
                <MenuItem Header="Properties" Command="Properties"/>
                <MenuItem Header="Tileset" Command="Replace"/>
            </MenuItem>
        </Menu>
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition />
                <ColumnDefinition />
                <ColumnDefinition />
            </Grid.ColumnDefinitions>
            <ListView />
            <Canvas Grid.Column="1"/>
            <Canvas Grid.Column="2"/>
        </Grid>
    </Grid>
 
