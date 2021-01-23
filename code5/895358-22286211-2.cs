    aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        lib_bt.Enabled = false;
        MessageBox.Show("Time Up!");
        button1.Enabled = false;
        button2.Enabled = false;
        button3.Enabled = false;
        button4.Enabled = false;
    }
