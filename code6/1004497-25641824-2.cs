    MainWindow.SetWatingMsg("please wait ...");
    
    Task.Factory.StartNew(() => doLongRunnnigTask());
    
    MainWindow.RemoveWaitingMsg();
    public void SetWaitMsg(string msg)
    {
        if (Session.User != null && Session.User.Configuration.DontShowWaitMsg)
                return;
    
        AppMainWindow.pleaseWaitBox.Visibility = Visibility.Visible;
    }
    
    public void RemoveWaitMsg()
    {
        AppMainWindow.pleaseWaitBox.Visibility = Visibility.Collapsed;
    }
