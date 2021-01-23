    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        Windows.UI.ViewManagement.InputPane.GetForCurrentView().Showing += MainPage_Showing;
        Windows.UI.ViewManagement.InputPane.GetForCurrentView().Hiding += MainPage_Hiding;
        
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        Windows.UI.ViewManagement.InputPane.GetForCurrentView().Showing -= MainPage_Showing;
        Windows.UI.ViewManagement.InputPane.GetForCurrentView().Hiding -= MainPage_Hiding;
        
    }
    void MainPage_Hiding(Windows.UI.ViewManagement.InputPane sender, Windows.UI.ViewManagement.InputPaneVisibilityEventArgs args)
    {
        Debug.WriteLine("Hiding and occluding {0}", sender.OccludedRect.Height);
    }
    void MainPage_Showing(Windows.UI.ViewManagement.InputPane sender, Windows.UI.ViewManagement.InputPaneVisibilityEventArgs args)
    {
        Debug.WriteLine("Showing and occluding {0}", sender.OccludedRect.Height);
    }
