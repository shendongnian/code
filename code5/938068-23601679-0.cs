     public static void UpdateAppTile(string navigationUri)
     {
       var tile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(navigationUri));
       if (tile != null)
       {
               var tileData = new FlipTileData
                {
                    SmallBackgroundImage = new Uri("/Assets/Tiles/small.png", UriKind.Relative),
                    BackgroundImage = new Uri("/Assets/Tiles/medium.png", UriKind.Relative),
                    WideBackgroundImage = new Uri("/Assets/Tiles/wide.png", UriKind.Relative),
                    // other properties
                };
                tile.Update(tileData);
        }
     }
