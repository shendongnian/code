    // modify Application Secondary Tile data
    private void updateTile_Click(object sender, RoutedEventArgs e)
    {
    	// get application specific tile - EXAMPLE
    	ShellTile Tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("Title=SecondaryTileEXAMPLE_TITLE"));
    	if (null != tile)
    	{
    		// create a new data for tile
    		StandardTileData data = new StandardTileData();
    		// tile foreground data
    		data.Title = "Title text here";
    		data.BackgroundImage = new Uri("/Images/Blue.jpg", UriKind.Relative);
    		data.Count = random.Next(99);
    		// to make tile flip add data to background also
    		data.BackTitle = "Secret text here";
    		data.BackBackgroundImage = new Uri("/Images/Green.jpg", UriKind.Relative);
    		data.BackContent = "Back Content Text here...";
    		// update tile
    		tile.Update(data);
    	}
    }
