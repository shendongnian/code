    private int _updateCounter;
    public void Update()
    {
        xpProgressBar1.Position = _updateCounter++ * 10;
        ...
        // do not forget to stop timer
        if(xpProgressBar1.Position == 100)
        {
            timer1.Stop();
            ...
        }
    }
