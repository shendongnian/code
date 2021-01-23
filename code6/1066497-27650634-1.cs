    System.Windows.Threading.DispatcherTimer myDispatcherTimer = new System.Windows.Threading.DispatcherTimer();
    myDispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 100 Milliseconds 
    myDispatcherTimer.Tick += new EventHandler(tmr_Tick);
    myDispatcherTimer.Start();
    public void tmr_Tick(object o, EventArgs sender)
    {
        myTextBlock.Text = "test";
    }
