    foreach (var track in _tracks)
    {
        var name = track.Item1;
        var uri = new Uri(string.Format("{0}/{1}", "/Resources/raw", name), UriKind.Relative);
    
        var song = Song.FromUri(name, uri);
    
        Thread.Sleep(2000); // this value has to be longer than the track
        FrameworkDispatcher.Update();        
        MediaPlayer.Play(song); 
    
    }
