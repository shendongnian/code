    private void MainForm_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            ShowInTaskbar = false;
            Hide();
        }
    }
    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        ShowInTaskbar = true;
        Show();       
        WindowState = FormWindowState.Normal;
    }
