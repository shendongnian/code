    Timer mi_StatusTimer = new Timer();
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        mi_StatusTimer.Interval = 500;
        mi_StatusTimer.Tick += new EventHandler(OnTimerBugFix);
    }
    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        mi_StatusTimer.Start();
    }
    void OnTimerBugFix(object sender, EventArgs e)
    {
        mi_StatusTimer.Stop();
        statusStrip.Hide();
        Application.DoEvents();
        statusStrip.Show();
    }
