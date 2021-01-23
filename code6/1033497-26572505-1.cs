    protected override void OnFormClosing(FormClosingEventArgs e) {
        if (e.CloseReason != CloseReason.WindowsShutDown) {
            this.Visible = false;
            e.Cancel = true;
        }
        base.OnFormClosing(e);
    }
