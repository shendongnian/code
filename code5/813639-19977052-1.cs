    private DateTime timeToStop;
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            timeToStop = DateTime.Now.Add(DateTime.Parse(comboBox1.Text));
        }
        catch(Exception)
        {
            timeToStop = new DateTime(3000, 01, 01, 00, 00, 00);
        }
    }
    public void disableButton_Click(object sender, EventArgs e)
    {
        _Timer.Stop();
        _lastRun = DateTime.Now;
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
