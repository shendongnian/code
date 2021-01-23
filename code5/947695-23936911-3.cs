    private void FavoriteButton_Click(object sender, RoutedEventArgs e)
    {
         if(!App.ViewModel.FavoriteVideos.Contains(App.ViewModel.SelectedVideo)) {
             App.ViewModel.FavoriteVideos.Add(App.ViewModel.SelectedVideo);
         }
    }
