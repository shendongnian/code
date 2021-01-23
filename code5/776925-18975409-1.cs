     public partial class VIdeoStraming : PhoneApplicationPage
        {
            string VideoUrl,StreamingUrl;
            public VIdeoStraming()
            {
                InitializeComponent();
            }
    
            protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
            {
                base.OnNavigatedTo(e);
                VideoUrl = this.NavigationContext.QueryString["parameter0"];
                string Manifest="/Manifest";
                StreamingUrl = VideoUrl + Manifest;                     
            }
    
            private void PlayButton_Click(object sender, RoutedEventArgs e)
            {
                //Monitor the state of the content to determine the right action to take on this button being clicked
                //and then change the text to reflect the next action
                switch (video.CurrentState)
                {
                    case SmoothStreamingMediaElementState.Playing:
                        video.Pause();
                        PlayButton.Content = "Play";
                        break;
                    case SmoothStreamingMediaElementState.Stopped:
                    case SmoothStreamingMediaElementState.Paused:
                        video.Play();
                        PlayButton.Content = "Pause";
                        break;
                }
            }
    
            private void PlayButton_Loaded(object sender, RoutedEventArgs e)
            {
                switch (video.AutoPlay)
                {
                    case false:
                        PlayButton.Content = "Play";
                        break;
                    case true:
                        PlayButton.Content = "Pause";
                        break;
                }
            }
    
            private void StopButton_Click(object sender, RoutedEventArgs e)
            {
    
                //This should simply stop the playback
              
                    video.Stop();
                    //We should also reflect the chang on the play button
                    PlayButton.Content = "Play";
               
            }
    
            private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
            {
              
                video.CurrentStateChanged += new RoutedEventHandler(video_CurrentStateChanged);
                video.PlaybackTrackChanged += new EventHandler<Microsoft.Web.Media.SmoothStreaming.TrackChangedEventArgs>(video_PlaybackTrackChanged);
                //video.SmoothStreamingSource = new Uri("http://64.120.251.114:1945/live/sharedobjects/layoutvideo/mp4:1311370468970.MP4/Manifest");
                video.SmoothStreamingSource = new Uri(StreamingUrl);
                video.ManifestReady += new EventHandler<EventArgs>(video_ManifestReady);
            }
    
            //when use in mobile device
            void video_ManifestReady(object sender, EventArgs e)
            {
                SmoothStreamingMediaElement ssme = sender as SmoothStreamingMediaElement;
    
                if (ssme == null)
                {
                    return;
                }
    
                // Select the highest band of tracks which all have the same resolution.
                // maxMobileBitrate depends on the encoding settings
                const ulong maxMobileBitrate = 1000000;
                foreach (SegmentInfo segment in ssme.ManifestInfo.Segments)
                {
                    foreach (StreamInfo streamInfo in segment.AvailableStreams)
                    {
                        if (MediaStreamType.Video == streamInfo.Type)
                        {
                            List<TrackInfo> widestBand = new List<TrackInfo>();
                            List<TrackInfo> currentBand = new List<TrackInfo>();
                            ulong lastHeight = 0;
                            ulong lastWidth = 0;
                            ulong index = 0;
    
                            foreach (TrackInfo track in streamInfo.AvailableTracks)
                            {
                                index += 1;
    
                                string strMaxWidth;
                                string strMaxHeight;
                                // If can't find width/height, choose only the top bitrate.
                                ulong ulMaxWidth = index;
                                // If can't find width/height, choose only the top bitrate.
                                ulong ulMaxHeight = index;
                                // V2 manifests require "MaxWidth", while v1 manifests used "Width".
                                if (track.Attributes.TryGetValue("MaxWidth", out strMaxWidth) ||
                                    track.Attributes.TryGetValue("Width", out strMaxWidth))
                                {
                                    ulong.TryParse(strMaxWidth, out ulMaxWidth);
                                }
    
                                if (track.Attributes.TryGetValue("MaxHeight", out strMaxHeight) ||
                                    track.Attributes.TryGetValue("Height", out strMaxHeight))
                                {
                                    ulong.TryParse(strMaxHeight, out ulMaxHeight);
                                }
    
                                if (ulMaxWidth != lastWidth ||
                                    ulMaxHeight != lastHeight)
                                {
                                    // Current band is now finished, check if it is the widest.
                                    // If same size, current band preferred over previous
                                    // widest, because it will be of higher bitrate.
                                    if (currentBand.Count >= widestBand.Count)
                                    {
                                        //  A new widest band:
                                        widestBand = currentBand;
                                        currentBand = new List<TrackInfo>();
                                    }
                                }
    
                                if (track.Bitrate > maxMobileBitrate)
                                {
                                    break;
                                }
    
                                // Current track always gets added to current band.
                                currentBand.Add(track);
                                lastWidth = ulMaxWidth;
                                lastHeight = ulMaxHeight;
                            }
    
                            if (0 == widestBand.Count &&
                                0 == currentBand.Count)
                            {
                                // Lowest bitrate band is > maxMobileBitrate.
                                widestBand.Add(streamInfo.AvailableTracks[0]);
                            }
                            else if (currentBand.Count >= widestBand.Count)
                            {
                                // Need to check the last band which was constructed.
                                Debug.Assert(currentBand.Count > 0);
                                widestBand = currentBand; // Winner by default.
                            }
    
                            Debug.Assert(widestBand.Count >= 1);
                            streamInfo.RestrictTracks(widestBand);
                        }
                    }
                }
    
            }
            void video_PlaybackTrackChanged(object sender, Microsoft.Web.Media.SmoothStreaming.TrackChangedEventArgs e)
            {
                currentBitrate.Text = e.NewTrack.Bitrate.ToString();
            }
    
            void video_CurrentStateChanged(object sender, RoutedEventArgs e)
            {
                status.Text = video.CurrentState.ToString();
            }
    
            private void imghdrleft_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                NavigationService.GoBack();
            }
    
            private void imghdrright_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                NavigationService.Navigate(new Uri("/Planet41VIew/Settings.xaml", UriKind.RelativeOrAbsolute));
            }
        }
