      public static bool CheckIfTileExists(string tileUri)
                {
                    ShellTile shellTile = ShellTile.ActiveTiles.FirstOrDefault(
                        tile => tile.NavigationUri.ToString().Contains(tileUri));
                    if (shellTile == null)
                        return false;
                    return true;
                }
