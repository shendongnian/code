    static System.Windows.Threading.DispatcherTimer myTimer = new System.Windows.Threading.DispatcherTimer();
    
    public void DoInquiry()
    {
       // do your inquiry stuff
       ////////////////////////
      
       // Set Timer Interval
       myTimer.Interval = = new TimeSpan(0,5,0); // 5 Minutes
       // Set Timer Event
       myTimer.Tick += new EventHandler(TimerEventProcessor);
       // Start timer
       myTimer.Start();
    }
    
    private static void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
       ShowMessage("Please check on the status");  
    }
    
    protected void ShowMessage(string Message)
    {
       System.Windows.MessageBox.Show(Message);
    }
