        private void videosList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Make sure the videos actually loaded into the LongListSelector before allowing a selection.
            if (e.AddedItems.Count != 0)
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
        }
