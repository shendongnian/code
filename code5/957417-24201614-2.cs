    private void InitializePhoneApplication()
    {
        if (phoneApplicationInitialized)
            return;
        RootFrame = new TransitionFrame();
        RootFrame.Navigated += CompleteInitializePhoneApplication;
        RootFrame.NavigationFailed += RootFrame_NavigationFailed;
        RootFrame.Navigating += new NavigatingCancelEventHandler(RootFrame_Navigating);//Add Navigating
        phoneApplicationInitialized = true;
    }
