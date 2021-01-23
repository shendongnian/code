    System.Timers.Timer timer;
    
    private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        timer.Stop();
        timer.Start();
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    }
    
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Do something
    }
