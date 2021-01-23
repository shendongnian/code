    private void bgFileOpener_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (this.IsDisposed) // Don't do this if we've been closed already
        {
            // Kill the bg work:
            bgFileOpener.CancelAsync();
        }
        else
            websiteInput_rtxt.AppendText(e.UserState.ToString());
    }
