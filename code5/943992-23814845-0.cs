    TimeSpan t = new TimeSpan(0, 5, 0); // five minutes
    List<DateTime> _hourList;
    bool _soundPlayed = false;
    private void OnTimerTick()
    {
        DateTime now = DateTime.Now;
        foreach (var h in _hourList)
        {
            if ((now >= h) && (now <= (h + t)))
            {
                if (_lastDisplayState != DisplayState.Highlighted)
                {
                    _lastDisplayState = DisplayState.Highlighted;
                    ...
                }
                if (!_soundPlayed)
                {
                    _soundPlayed = true;
                    _soundPlayer.Play();
                }
                return;
            }
        }
        // if code runs until here, we are out of any highlighted moment
        _soundPlayed = false;
        if (_lastDisplayState != DisplayState.Normal)
        {
            _lastDisplayState = DisplayState.Normal;
            ...
        }
    }
