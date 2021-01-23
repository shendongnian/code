    /// <summary>
    /// Method checking type of the last page on the BackStack
    /// </summary>
    /// <param name="desiredPage">desired page type</param>
    /// <returns>true if last page is of desired type, otherwise false</returns>
    private bool CheckLastPage(Type desiredPage)
    {
        var lastPage = Frame.BackStack.LastOrDefault();
        return (lastPage != null && lastPage.SourcePageType.Equals(desiredPage)) ? true : false;
    }
    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (CheckLastPage(typeof(MainPage)))
        {
            // do your job
            await new MessageDialog("Previous is MainPage").ShowAsync();
        }
    }
