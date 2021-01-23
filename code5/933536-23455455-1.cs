    [TestCase("app domain name for instance of App")]
    [TestCase("app domain name for another instance of App")]
    public void ApplicationTest(string name)
    {
        AppDomain appDomain = AppDomain.CreateDomain(name);
        appDomain.DoCallBack(StartApp);
        Assert.IsTrue((bool)appDomain.GetData("GuiVisible"));
    }
    // using a static method instead of a lambda makes sure
    // you haven't captured anything
    private static void StartApp()
    {
        app = new App();
        app.InitializeComponent();
        app.Dispatcher.BeginInvoke(DispatcherPriority.Loaded,
           new Action(() => AppOnActivated()));
        app.Run();
    }
    private static void AppOnActivated()
    {
        var mainWindow = (MainWindow)Application.Current.MainWindow;
        mainWindow.ButtonViewModel = new ButtonViewModel();
        mainWindow.ButtonViewModel.Name = "bla";
        AppDomain.CurrentDomain.SetValue("GuiVisible") = true;
        app.Shutdown();
    }
