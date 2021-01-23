    [Test]
    public void Tick_UpdateTracks_TracksUpdated()
    {
        _uut.IncomingTrack(_track);
        _uut.Tick();
        _track.Received().update();
    }
