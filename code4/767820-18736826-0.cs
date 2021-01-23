    mediaPlayer = new MediaPlayer();
    mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
    mediaPlayer.Open(new Uri(mediaFilePath, UriKind.Absolute));
    ...
    private void MediaPlayer_MediaOpened(object sender, EventArgs e)
    {
        if (mediaPlayer.NaturalDuration.HasTimeSpan)
        {
            SliderMaximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            mediaPlayer.Play();
        }
    }
