        protected override void OnInvoke(ScheduledTask task)
        {
            ShellTile tile = ShellTile.ActiveTiles.FirstOrDefault();
            if (tile != null)
            {
                FlipTileData flipTile = new FlipTileData();
                flipTile.Title = "";
                flipTile.BackTitle = "Atmosphere";
                Deployment.Current.Dispatcher.BeginInvoke(delegate() { RenderText("Test"); });
                Deployment.Current.Dispatcher.BeginInvoke(delegate() { RenderTextWide("Test"); });
                flipTile.BackBackgroundImage = new Uri("/Assets/NewUI/1.PNG", UriKind.Relative); //Default image for Background Image Medium Tile 336x336 px
                flipTile.BackgroundImage = new Uri(@"isostore:/Shared/ShellContent/BackBackgroundImage2.png", UriKind.Absolute); //Generated image for Back Background 336x336
                flipTile.WideBackBackgroundImage = new Uri("/Assets/NewUI/2.PNG", UriKind.Relative); ////Default image for Background Image Wide Tile 691x336 px
                flipTile.WideBackgroundImage = new Uri(@"isostore:/Shared/ShellContent/WideBackBackgroundImage2.png", UriKind.Absolute);
                tile.Update(flipTile);
                //Tile updated, tell agent operation complete
                NotifyComplete();
            }
        }
