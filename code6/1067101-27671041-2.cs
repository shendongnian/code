    System.Timers.Timer timer = new System.Timers.Timer(2000);;
    timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    timer.Enabled = false;
    private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        timer.Enabled = false;
        timer.Enabled = true;   
    }
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Do something
        timer.Enabled = false;
    }
