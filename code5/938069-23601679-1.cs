     public static void DeleteAppTile(string navigationUri)
     {
       var tile =  ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(navigationUri));
       if (tile != null)
       {
         tileToFind.Delete();
       }
     }
