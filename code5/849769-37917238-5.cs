    private void UpdateSeekBar()
    {
    	if (_playbackState == PlaybackState.Playing)
    	{
    		CurrentTrackPosition = _audioPlayer.GetPositionInSeconds();
    	}
    }
    
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	UpdateSeekBar();
    }
