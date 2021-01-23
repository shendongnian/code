    void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
    {
        // Get the new view state
        string CurrentViewState = ApplicationView.GetForCurrentView().Orientation.ToString();
        var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
        if (CurrentViewState == "Portrait")
        {
            bottombar.Visibility = Visibility.Visible;
            ShowStatusBar();                      
        }
        if (CurrentViewState == "Landscape")
        {
            bottombar.Visibility = Visibility.Collapsed;
            HideStatusBar();
        }
    }
    private async void ShowStatusBar()
    {
        var statusBar = StatusBar.GetForCurrentView();
        await statusBar.ShowAsync();
    }
    private async void HideStatusBar()
    {
        var statusBar = StatusBar.GetForCurrentView();
        await statusBar.HideAsync();
    }
