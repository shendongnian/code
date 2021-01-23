    bool flag;
    DispatcherTimer timer;
    public constructor()
    {
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s,e) => {
            flag = false;
            timer.Stop()
            DoThrottledEvent();
        }
    }
    
    void mouse_enter(object sender, MouseEventArgs args)
    {
        if(!flag)
        {
            flag = true;
            timer.Start();
        }
    }
    void DoThrottledEvent()
    {
        //code for event here
    }
