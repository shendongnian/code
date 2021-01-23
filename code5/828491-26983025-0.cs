        public enum PanoramaItem
        {
            None = -1, Account, Game, Help
        }
        public void PanoramaNavigateTo(PanoramaItem item)
        {
            panorama.DefaultItem = panorama.Items[(int)item];
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            viewGame.cmdPlay.Click += new RoutedEventHandler(CmdPlayGame);
        }
        private void CmdPlayGame(object sender, RoutedEventArgs e)
        {
            PanoramaNavigateTo(PanoramaItem.Game);
        }
