        void Instance_PlayStateChanged(object sender, EventArgs e)
        {
            switch (BackgroundAudioPlayer.Instance.PlayerState)
            {
              case PlayState.Playing:
                playButton.Content = "pause";
                break;
        
              case PlayState.Paused:
              case PlayState.Stopped:
                playButton.Content = "play";
                break;
            }
        
            if (null != BackgroundAudioPlayer.Instance.Track)
            {
              txtCurrentTrack.Text = BackgroundAudioPlayer.Instance.Track.Title +
                                     " by " +
                                     BackgroundAudioPlayer.Instance.Track.Artist;
            }
        }
        
        [enter link description here][1]
    
    [1]: http://msdn.microsoft.com/en-us/library/windowsphone/develop/hh202978%28v=vs.105%29.aspx
          
