    private void HeaderPanelOnMouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && e.Clicks >= 2) {
            MaximizeOnClick(sender, e);
            return;
        }
        if (e.Button != MouseButtons.Left) {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }
