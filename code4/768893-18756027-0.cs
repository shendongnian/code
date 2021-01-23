    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        if (ApplicationData.Current.LocalSettings.Values["LastPage"] != null)
        {
            .......
    
            Type t = Type.GetType((string)ApplicationData.Current.LocalSettings.Values["LastPage"]);
            rootFrame.Navigate(typeof(t), args.Arguments);
    
            .......
        }
        else
        {
            rootFrame.Navigate(typeof(MainPage), args.Arguments);
        }
    }
