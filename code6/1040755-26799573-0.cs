    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        DataTransferManager.GetForCurrentView().DataRequested += SharePage_DataRequested;
    }
    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        base.OnNavigatingFrom(e);
        DataTransferManager.GetForCurrentView().DataRequested -= SharePage_DataRequested;
    }
