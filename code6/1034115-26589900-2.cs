    public static void timerElapsed(object sender, ElapsedEventArgs e)
    {
        timer.Stop();              // stop the timer
        MessageBox.Show("Hello");
        timer.Start();             // restart it; you'll get another msg in 10 seconds
    }
