    internal System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
    ....
    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      ni.Icon = Null;
    }
