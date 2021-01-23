    protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            if ((BackgroundAudioPlayer.Instance.PlayerState == PlayState.Playing) && (BackgroundAudioPlayer.Instance.CanSeek))
            {
                BackgroundAudioPlayer.Instance.Pause();
            }
        }
    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (BackgroundAudioPlayer.Instance.PlayerState == PlayState.Pause) 
                {
                    BackgroundAudioPlayer.Instance.PlayerState = BackgroundAudioPlayer.Instance.Play();
                }
        }
