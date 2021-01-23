    private void UpdateStatus(string message)
    {
        Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
        {
            statusBar1.Text = message;
       }));
    }
