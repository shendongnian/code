    ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault();
                       if (tile != null)
                       {
                           FlipTileData data = new FlipTileData()
                           {
                               SmallBackgroundImage = new Uri("isostore:/Shared/ShellContent/" + mediumTile, UriKind.RelativeOrAbsolute),
                               BackgroundImage = new Uri("isostore:/Shared/ShellContent/" + mediumTile, UriKind.RelativeOrAbsolute),
                               WideBackgroundImage = new Uri("isostore:/Shared/ShellContent/" + wideTile, UriKind.RelativeOrAbsolute)
                           };
    
                       tile.Update(data);
                   }
    NotifyComplete();
