    private void dispatcherTimerCheckPopupPrinter_Tick(object sender, EventArgs e)
    {
        var timer = (DispatcherTimer)sender; // not Dispatcher!
        timer.Stop(); // or timer.IsEnabled = false;
    }
