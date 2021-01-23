    private DateTime timeToStop;
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        timeToStop = DateTime.Now.Add(DateTime.Parse(comboBox1.Text));
    }
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (DateTime.Now >= timeToStop)
        {           
            _Timer.Stop();
            _lastRun = DateTime.Now;
            // Disable regkey
        }
    }
