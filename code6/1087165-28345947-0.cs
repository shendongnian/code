    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (backgroundWorker2.IsBusy)
        {
            e.Cancel = true;
            return;
        }
        base.OnFormClosing(e);
    }
