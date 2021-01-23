    public string Uri { get; set; } 
    
        private async void PlayVideo()
        {
                string VideoUrl = "http://www.youtube.com/watch?v=2rJwYN_SmOU";
                var url = await YouTube.GetVideoUriAsync("2rJwYN_SmOU", YouTubeQuality.Quality360P);
                meTestVideo.Source = url.Uri;
        }
