    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        var lastPage = Frame.BackStack.LastOrDefault();
        if (lastPage != null && lastPage.SourcePageType.Equals(typeof(MainPage)))
        {
            // do your job
            await new MessageDialog("Previous is MainPage").ShowAsync();
        }
    }
