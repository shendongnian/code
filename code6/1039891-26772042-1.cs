    private void TimerTick(object Sender, ElapsedEventArgs e)
    {
        _myTimer.Enabled = false;
        // do processing
        // then re-enable the timer
        _myTimer.Enabled = true;
    }
