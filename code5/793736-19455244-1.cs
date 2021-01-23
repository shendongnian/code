    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        object lastPage;
        if((e.NavigationMode == NavigationMode.Back) &&
            (PhoneApplicationService.Current.State.TryGetValue("LastPage", out lastPage)))
        {
            // we navigated back and we know what the last page was!
            var pageName = lastPage.GetType().Name;
            if (pageName == "Page1.xaml")
            {
                // do something!
            }
        }
    }
