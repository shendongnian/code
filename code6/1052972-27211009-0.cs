    public MainPage()
    {
        this.InitializeComponent();
        SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
    }
    private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs spcreArgs)
    {
        spcreArgs.Request.ApplicationCommands.Add(new SettingsCommand(1, "App Bar Color", OnSettingsCommand));
        spcreArgs.Request.ApplicationCommands.Add(new SettingsCommand(2, "Visit Types to Display", OnSettingsCommand));
        spcreArgs.Request.ApplicationCommands.Add(new SettingsCommand(3, "Display Current Location", OnSettingsCommand));
        spcreArgs.Request.ApplicationCommands.Add(new SettingsCommand(4, "Set Home Base", OnSettingsCommand));
    }
    private void OnSettingsCommand(Windows.UI.Popups.IUICommand command)
    {
        int id = (int)command.Id;
        switch (id)
        {
            case 1:
                //Bla => I think this is where I need to add "this.[custom settings pane (user control) name].Show(command)
                break;
            case 2:
                //Bla
                break;
            case 3:
                //Bla
                break;
            case 4:
                //Bla
                break;
        }
    }
