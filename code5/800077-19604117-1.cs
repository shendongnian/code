    static Stopwatch sw = new Stopwatch();
    
    private void Start_Click(object sender, EventArgs e)
    {
        sw.Start();
    }
    private void stopButton_Click(object sender, EventArgs e)
    {
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", 
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        MessageBox.Show("Elapsed time = " + elapsedTime);
    }
