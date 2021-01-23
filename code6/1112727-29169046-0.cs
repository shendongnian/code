    [ClassInitialize]
    public void ClassInitialize()
    {
        Playback.Initialize();
        MyCodedUITests.StartTest();
        
        // dev
        //GlobalVariables.Browser = BrowserWindow.Launch(new Uri(@"http://ThesiteIlaunch"));
        // prod
        GlobalVariables.Browser = BrowserWindow.Launch(new Uri(@"http://ThesiteILauch"));
        GlobalVariables.Browser.CloseOnPlaybackCleanup = false;
        GlobalVariables.Browser.Maximized = true;
    }
