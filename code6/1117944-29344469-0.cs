    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
    string launchString = args.Arguments
        If (  launchString ….)
        {
        rootFrame.Navigate(typeof(page2));
        }
        else
        {
        rootFrame.Navigate(typeof(MainPage));
        }
    ...
    }
