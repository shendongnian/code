    public static void timerElapsed(object sender, ElapsedEventArgs e)
    {
        timer.Enabled = false;     // stop the timer
        MessageBox.Show("Hello");
        timer.Enabled = true;      // restart it; you'll get another msg in 10 seconds
    }
