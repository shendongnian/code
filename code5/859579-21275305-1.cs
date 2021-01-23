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
        
        
