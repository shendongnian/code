    private void TrackControlMouseDown(object p)
    {
    	_audioPlayer.Pause();
    }
    
    private void TrackControlMouseUp(object p)
    {
    	_audioPlayer.SetPosition(CurrentTrackPosition);
    	_audioPlayer.Play(NAudio.Wave.PlaybackState.Paused, CurrentVolume);
    }
    
    private bool CanTrackControlMouseDown(object p)
    {
    	if (_playbackState == PlaybackState.Playing)
    	{
    		return true;
    	}
    	return false;
    }
    
    private bool CanTrackControlMouseUp(object p)
    {
    	if (_playbackState == PlaybackState.Paused)
    	{
    		return true;
    	}
    	return false;
    }
