    void Current_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        CustomMessageBoxViewModel messageBox = new CustomMessageBoxViewModel();
        messageBox.Sender = sender;
        messageBox.Exception = e.Exception;
        CustomMessageBoxWindow messageBoxWindow = new CustomMessageBoxWindow();
        messageBoxWindow.DataContext = messageBox;
        messageBoxWindow.ShowDialog();
        e.Handled = true;
    }
