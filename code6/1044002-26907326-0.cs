        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var albumId = ((Album)e.ClickedItem).Id;
            if (!Frame.Navigate(typeof(AlbumPage), albumId))
            {
                var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
                throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }
