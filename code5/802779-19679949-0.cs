    private void timMessung_Tick(object sender, EventArgs e)
    {
        if (timMessung.Enabled == true)
        {
            stopwatch.Restart();
        }
        else
        {
            ts.stopwatch.Elapsed();
        }
    }
