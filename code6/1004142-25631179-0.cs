    private void gameTick(object sender, System.Timers.ElapsedEventArgs e)
    {
        gameTimer.Enabled = false;
        theGame.Update(e.SignalTime.Second);
        this.Invalidate();
        gameTimer.Enabled = true;
    }
