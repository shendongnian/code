    <Grid>
            <Menu x:Name="mainMenu">
                <MenuItem  Header="File" Click="OnFileMenuItemClicked">
                    <MenuItem Header="Open Analysis">
                        <MenuItem Header="Load all" />
                        <MenuItem Header="Select from tracks" />
                    </MenuItem>
                </MenuItem>
            </Menu>
    </Grid>
    private void OnFileMenuItemClicked(object sender, RoutedEventArgs e)
    {
        MenuItem item = e.OriginalSource as MenuItem;
        if(null != item)
        {
            // Handle the menuItem click here
        }
    }
