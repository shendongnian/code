    private int _updateCounter;
    public void Update()
    {
        xpProgressBar1.Position = _updateCounter++ * 10;
        ...
        // do not forget to stop timer
        if(xpProgressBar1.Position == 100)
        {
            timer1.Stop();
            _updateCounter = 0; // add some cleanup if using timer more than once
            _timer1Ticks = 0;
            ...
        }
    }
