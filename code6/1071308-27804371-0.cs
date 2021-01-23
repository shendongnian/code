    private int countDown = 50; //Or initialize at load time, or whatever
    public void TimerTick(...)
    {
        label2.Text = (TimeSpan.FromMinutes(0.1) - (DateTime.Now - startTime)).ToString("hh\\:mm\\:ss");
        countDown--;
    
        if (countDown <= 0)
           timer.Stop();
    }
