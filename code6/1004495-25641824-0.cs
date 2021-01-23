    public void SetWaitMsg(string msg)
    {
        if (Session.User != null)
            if (Session.User.Configuration.DontShowWaitMsg)
                return;
    
        AppMainWindow.Dispatcher.BeginInvoke(DispatcherPriority.Render, (System.Action)delegate()
        {
            AppMainWindow.pleaseWaitBox.Visibility = Visibility.Visible;
        });
    }
    
    public void RemoveWaitMsg()
    {
        AppMainWindow.Dispatcher.BeginInvoke(DispatcherPriority.Render, (System.Action)delegate() { AppMainWindow.pleaseWaitBox.Visibility = Visibility.Collapsed; });
    }
