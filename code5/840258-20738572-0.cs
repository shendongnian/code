        private void videosList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (videosList.SelectedItem == null)
                return;
            Video v = videosList.SelectedItem as Video;
            App.Current.Resources.Add("video", v);
            //NavigationService.Navigate(new Uri("/Pages/VideoPlayer.xaml", UriKind.RelativeOrAbsolute));
            LoadVideosMediaLauncher();
            // Reset selected item to null (no selection)
            videosList.SelectedItem = null;
        } 
