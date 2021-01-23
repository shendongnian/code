    private void UpdateStatus(string message)
    {
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
        {
            statusBar1.Text = message;
       }));
    }
