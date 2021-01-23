    private void UpdateStatusBar(int progress)
    {
        if (!Application.Current.Dispatcher.CheckAccess())
        {
            Application.Current.Dispatcher.Invoke(() => UpdateStatusBar(progress));
            return;
        }
    
        // update status here
    }
