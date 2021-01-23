    private void AnimateKey(int Start, int Stop)
    {
        myTimer.Interval = 5;
        myTimer.Tick += (s, args) => myTimer_Tick(Start, Stop);
        myTimer.Enabled = true;
        myTimer.Start();
    }
    private void myTimer_Tick(int Start, int Stop)
    {
        //Do stuff
    }
