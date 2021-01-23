    private void onResize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)  // only hide if minimizing the form
        {
            this.ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            this.Visible = false;
        }
    }
