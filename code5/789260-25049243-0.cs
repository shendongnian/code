    private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
        bool videoSuccess = true;
        try {
        var videoUri = await MyToolkit.Multimedia.YouTube.GetVideoUriAsync("Youtube_ID", MyToolkit.Multimedia.YouTubeQuality.Quality480P, MyToolkit.Multimedia.YouTubeQuality.Quality480P);
        if (videoUri != null)
            player.Source = videoUri.Uri; 
        }
        catch (Exception e) { // Debug and find out which exception is being thrown
        videoSuccess = false;    
        }
        if (videoSuccess == false) {
        await MessageDialog.ShowAsync("Video couldn't be played.","No Internet"); }                
        }
