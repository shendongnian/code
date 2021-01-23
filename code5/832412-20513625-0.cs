    static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
    
    public void DoInquiry()
    {
       // do your inquiry stuff
       ////////////////////////
      
       // Set Timer Interval
       myTimer.Interval = 300000; // 5 Minutes
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
       System.Windows.Forms.MessageBox.Show(Message);
    }
