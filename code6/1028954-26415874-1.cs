    protected override void OnResize(EventArgs e)
    {
        if (this.WindowState == FormWindowState.Maximized || 
            this.WindowState == FormWindowState.Normal)
        {
            // Do something here
        }
        // You should probably call the base implementation too
        base.OnResize(e);
        // Note that calling base.OnResize will trigger 
        // Form1_Resize(object sender, EventArgs e)
        // which is normally where you handle resize events
    }
