    private void InitLoop(bool runLoop)
    {
        try
        {
            myTimer.Elapsed += myTimer_Elapsed;
            myTimer.Interval = 2000;
            myTimer.Enabled = true;
            myTimer.Start();
        }
        catch (Exception f)
        {
            //handle the exception 
        }
    }
