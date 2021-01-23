    private void button1_Click(object sender, EventArgs e)
	{
        button1.Text = "stop"
        aTimer = new System.Timers.Timer(5000);
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Enabled = true;
    }
    // Specify what you want to happen when the Elapsed event is  raised. 
    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        button1.Text = "Start";
        var atim = source as Timer;
        if (atim != null)
           atim.Elapsed  -= OnTimedEvent;
    }
