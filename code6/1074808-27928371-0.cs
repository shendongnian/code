    public async Task HideProgressAsync()
    {
        var statusBar = Windows.UI.ViewManagement.StatusBar.GetForCurrentView();
        await statusBar.ProgressIndicator.HideAsync();
    }
