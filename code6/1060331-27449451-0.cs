    private void BeginMonitoringClick()  { 
    {
        myTimer.Tick += TimerEventProcessor; // myTimer declared elsewhere
        myTimer.Interval = 2000;
        myTimer.Start();
    }
    
    private void TimerEventProcessor(object myObject, EventArgs e) {
        // Talk to hardware, see if it is doing OK
    }
