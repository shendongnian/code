    ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("any string of uri or search for unique prop"));
    if (TileToFind == null)
    {
       ShellTile.Create(Navi_Uri , tileData, true);
       MessageBox.Show("Tile is created.");
    }
    else
    {
       TileToFind.Update(tileData);
       MessageBox.Show("Tile is updated");
    }
