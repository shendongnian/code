    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //base.OnNavigatedTo(e); //this call isn't necessary
        if (e.NavigationMode == NavigationMode.New)
        {
           storyboardTo.Begin();
        }
        //if NavigationMode is Back then don't play the animation
        //...
    }
    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
        if (e.NavigationMode != NavigationMode.Back)
        {//leave the page due to long back button or Windows button, stay on the page
            e.Cancel = true;
            return;
        }
        //...
        //base.OnNavigatingFrom(e); //this call isn't necessary
        //...
    }
