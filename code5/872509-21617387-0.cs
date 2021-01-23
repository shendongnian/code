    delegate void updatePanelCallback();
    panel1.MouseDown += new MouseEventHandler(onMouseDown);
    panel1.MouseUp += new MouseEventHandler(onMouseUp);
    System.Timers.Timer runTimer = new System.Timers.Timer(100);
    runTimer.Elapsed += new ElapsedEventHandler(onTimerElapsed);
    private void onMouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right)
        {
            return;
        }
        runTimer.Enabled = false;
    }
    private void onMouseUp(object sender, MouseEventArgs e)
    {
        runTimer.Enabled = false;
    }
    public void updatePanelLocation()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new updatePanelCallback(updatePanelLocation), new object[] {});
        }
        else
        {
            Cursor curs = new Cursor(Cursor.Current.Handle);
            panel1.Location = curs.Position;
        }
    }
    private void onTimerElapsed(object source, ElapsedEventArgs e)
    {
        updatePanelLocation();
    }
