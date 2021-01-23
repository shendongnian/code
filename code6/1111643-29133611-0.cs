    private void timer_Tick(object sender, EventArgs e)
    {
        if (progressBar.Value != 10)
        {
            progressBar.Value++;
        }
        else
        {
            splashScreenTimer.Stop();
        }
    }
