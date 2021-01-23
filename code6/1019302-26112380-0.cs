    void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
      Observable.FromEventPattern(_playPauseButton, "Click")
                .Scan(false, (play, _) => !play)
                .Subscribe(play => { if (play) Play(); else Pause(); });
    }
    private void Play()
    {
      _playPauseButton.Content = "Pause";
    }
    private void Pause()
    {
      _playPauseButton.Content = "Play";
    }
