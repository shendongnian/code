    protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
    {
        // Fires Closing event
        base.OnClosing(e);
        if (!e.Cancel)
        {
            // Window was allowed to close.
            // Set IsClosed = true or something like that
        }
    }
