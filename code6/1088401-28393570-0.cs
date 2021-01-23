    Timer NewTimer;
    int secval;
    int tsecs;
    ...
    secVal = int.Parse(BoxSecond.Text);
    tsecs = secVal;
    NewTimer= new Timer(1000);
    NewTimer.Elapsed += NewCounter;
            
    private void TStartStop_Click(object sender, EventArgs e)
    {
        ...
        NewTimer.Start();
    }
    
    private void NewCounter(Object source, ElapsedEventArgs e)
    {
        TimeNow= DateTime.Now;
        if (TimeBefore != null)
        {
            if (TimeNow.Second - TimeBefore.Second == 2)
            {
                tsecs--; 
                ...
                //Invoke for label
            }
            else if (TimeNow.Second - TimeBefore.Second == 0)
            {
                tsecs++;
                ...
                //Invoke for label
            }
        }
        TimeBefore = DateTime.Now;
        ...
        
        if(tsecs != 0)
        {
            tsecs--;
            //Invoke for label
        }
        else if(tsecs == 0)
        {
            tsecs = secVal;
            tsecs--;
            //Invoke for label
        }
    }
