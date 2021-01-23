    private bool _inTimer = false;
    private void TimerTick(object Sender, ElapsedEventArgs e)
    {
        if (_inTimer)
        {
            // there's already a timer running.
            // log a message or notify you in some other way.
        }
        _inTimer = true;
        // do your processing here
        // and then clear the flag
        _inTimer = false;
    }
